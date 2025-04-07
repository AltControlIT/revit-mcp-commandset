namespace RevitMCPCommandSet.Utils;

public class HandleDuplicateTypeUtils : IDuplicateTypeNamesHandler
{
    public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
    {
        return DuplicateTypeAction.UseDestinationTypes;
    }
}
