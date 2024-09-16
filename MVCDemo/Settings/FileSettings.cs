namespace MVCDemo.Settings
{
    public static class FileSettings
    {
        public const string ImagePath = "/Assets/images/games";
        public const string AllowedExtentions = ".jpg,.jpeg,.png";
        public const int  MaxFileSizeInMB = 1 ;
        public const int MaxFileSizeInByte = MaxFileSizeInMB * 1024 * 1024 ;
    }
}
