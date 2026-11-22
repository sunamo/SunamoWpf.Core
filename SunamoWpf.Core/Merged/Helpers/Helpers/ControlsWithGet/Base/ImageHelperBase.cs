#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet.Base;

/// <summary>
/// Represents the image helper base image source image control type.
/// </summary>
public  abstract partial class ImageHelperBase<ImageSource, ImageControl>
    {
        /// <summary>
        /// Ms appx i.
        /// </summary>
        /// <param name="appPic2">The app pic 2.</param>
        /// <returns>The ms appx i result.</returns>
        public abstract ImageControl MsAppxI(string appPic2);
        /// <summary>
        /// Ms appx.
        /// </summary>
        /// <param name="relPath">The rel path.</param>
        /// <returns>The ms appx result.</returns>
        public abstract ImageControl MsAppx(string relPath);
        /// <summary>
        /// Ms appx.
        /// </summary>
        /// <param name="disabled">The disabled.</param>
        /// <param name="appPic">The app pic.</param>
        /// <returns>The ms appx result.</returns>
        public abstract ImageControl MsAppx(bool disabled, AppPics appPic);
    }