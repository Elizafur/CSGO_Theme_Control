namespace CSGO_Theme_Control.Base_Classes.Logger
{
    public static class LoggerSettings
    {
        //TODO(Low): This should be expanded to include other option types.
        public enum CleanupOptions
        {
            CLEANUP_THROWN_LOGS,
            CLEANUP_LOGS_ONLY_IF_BEFORE_TODAY   //TODO(Low): Rename to something better?
        }

    }
}
