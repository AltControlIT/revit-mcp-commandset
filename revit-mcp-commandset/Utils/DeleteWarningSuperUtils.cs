namespace RevitMCPCommandSet.Utils;

public class DeleteWarningSuperUtils : IFailuresPreprocessor
{
    public int NumberErr;

    public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
    {
        FailureProcessingResult failureProcessingResult;
        var failList = failuresAccessor.GetFailureMessages();
        if (failList.Count != 0)
        {
            foreach (var failure in failList)
            {
                var s = failure.GetSeverity();
                var failureDefinitionId = failure.GetFailureDefinitionId();

                if (s == FailureSeverity.Warning)
                {
                    if (failureDefinitionId == BuiltInFailures.GeneralFailures.DuplicateValue)
                        failuresAccessor.DeleteWarning(failure);
                    else
                        failuresAccessor.DeleteWarning(failure);
                }
                else if (s == FailureSeverity.Error)
                {
                    failuresAccessor.ResolveFailure(failure);
                    NumberErr += 1;
                }
            }

            failureProcessingResult = FailureProcessingResult.ProceedWithCommit;
        }
        else
        {
            failureProcessingResult = FailureProcessingResult.Continue;
        }

        return failureProcessingResult;
    }
}
