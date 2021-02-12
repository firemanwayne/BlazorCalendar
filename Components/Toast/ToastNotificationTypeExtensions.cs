namespace Components.Toast
{
    public static class ToastNotificationTypeExtensions
    {
        public static string ToCss(this ToastNotificationType color)
        {
            string colorvalue;

            colorvalue = color == ToastNotificationType.Warning ? "alert alert-warning" :
                color == ToastNotificationType.Error ? "alert alert-danger" :
                color == ToastNotificationType.Info ? "alert alert-info" :
                color == ToastNotificationType.Success ? "alert alert-success" : "";

            return colorvalue;
        }

        public static string ToCss(this ToastTextColor color)
        {
            string colorvalue;

            colorvalue = color == ToastTextColor.Red ? "text-danger" :
                    color == ToastTextColor.Blue ? "text-primary" :
                    color == ToastTextColor.Green ? "text-success" :
                    color == ToastTextColor.Orange ? "text-warning" :
                    color == ToastTextColor.Black ? "text-dark" :
                    color == ToastTextColor.White ? "text-light" :
                    color == ToastTextColor.Dark ? "text-dark" :
                    color == ToastTextColor.Muted ? "text-muted" :
                    color == ToastTextColor.LightBlue ? "text-info" : "";

            return colorvalue;
        }
    }
}
