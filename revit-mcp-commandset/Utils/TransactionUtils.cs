namespace RevitMCPCommandSet.Utils;

///     Utilities for handling transactions in Revit
public static class TransactionUtils
{
    ///     Execute an operation within a transaction
    public static T ExecuteInTransaction<T>(Document doc, string transactionName, Func<T> action)
    {
        using var transaction = new Transaction(doc, transactionName);
        transaction.Start();
        try
        {
            var result = action();
            transaction.Commit();
            return result;
        }
        catch (Exception ex)
        {
            transaction.RollBack();
            throw new Exception($"Error executing '{transactionName}': {ex.Message}", ex);
        }
    }

    ///     Execute an operation within a transaction (no return value)
    public static void ExecuteInTransaction(Document doc, string transactionName, Action action)
    {
        using var transaction = new Transaction(doc, transactionName);
        transaction.Start();
        try
        {
            action();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.RollBack();
            throw new Exception($"Error executing '{transactionName}': {ex.Message}", ex);
        }
    }

    ///     Execute a series of operations within a transaction, returning a list of results
    public static List<R> ExecuteBatchInTransaction<T, R>(Document doc, string transactionName,
        IEnumerable<T> items, Func<T, R> actionPerItem)
    {
        var results = new List<R>();

        using var transaction = new Transaction(doc, transactionName);
        transaction.Start();
        try
        {
            foreach (var item in items)
            {
                var result = actionPerItem(item);
                results.Add(result);
            }

            transaction.Commit();
            return results;
        }
        catch (Exception ex)
        {
            transaction.RollBack();
            throw new Exception($"Error executing batch '{transactionName}': {ex.Message}", ex);
        }
    }

    ///     Execute a series of operations within a transaction (no return value)
    public static void ExecuteBatchInTransaction<T>(Document doc, string transactionName,
        IEnumerable<T> items, Action<T> actionPerItem)
    {
        using var transaction = new Transaction(doc, transactionName);
        transaction.Start();
        try
        {
            foreach (var item in items) actionPerItem(item);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.RollBack();
            throw new Exception($"Error executing batch '{transactionName}': {ex.Message}", ex);
        }
    }

    ///     Execute an operation within a transaction group (enables undo/redo as a group)
    public static T ExecuteInTransactionGroup<T>(Document doc, string groupName, Func<T> action)
    {
        using var group = new TransactionGroup(doc, groupName);
        group.Start();
        try
        {
            var result = action();
            group.Assimilate();
            return result;
        }
        catch (Exception ex)
        {
            group.RollBack();
            throw new Exception($"Error executing transaction group '{groupName}': {ex.Message}", ex);
        }
    }

    ///     Execute an operation within a transaction group (no return value)
    public static void ExecuteInTransactionGroup(Document doc, string groupName, Action action)
    {
        using var group = new TransactionGroup(doc, groupName);
        group.Start();
        try
        {
            action();
            group.Assimilate();
        }
        catch (Exception ex)
        {
            group.RollBack();
            throw new Exception($"Error executing transaction group '{groupName}': {ex.Message}", ex);
        }
    }

    ///     Execute material operation within a transaction
    public static bool SetMaterialInTransaction(Document doc, Element element, string materialName)
    {
        return ExecuteInTransaction(doc, "Set Material", () =>
        {
            // Find material by name
            var material = new FilteredElementCollector(doc)
                .OfClass(typeof(Material))
                .Cast<Material>()
                .FirstOrDefault(m => m.Name.Equals(materialName, StringComparison.OrdinalIgnoreCase));

            if (material == null)
                return false;

            // Get material parameter
            var materialParam = element.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            if (materialParam != null && !materialParam.IsReadOnly)
            {
                materialParam.Set(material.Id);
                return true;
            }

            return false;
        });
    }

    ///     Wrap exception in a transaction to ensure rollback if error occurs
    public static bool SafeExecuteInTransaction(Document doc, string transactionName, Action action,
        Action<Exception> errorHandler = null)
    {
        using var transaction = new Transaction(doc, transactionName);
        transaction.Start();
        try
        {
            action();
            transaction.Commit();
            return true;
        }
        catch (Exception ex)
        {
            transaction.RollBack();
            if (errorHandler != null) errorHandler(ex);
            return false;
        }
    }
}
