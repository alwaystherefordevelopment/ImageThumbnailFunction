using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Drawing;
using System.IO;

namespace ImageThumbnailFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [BlobTrigger("images/{name}", Connection = "StorageConnection")] Stream picture,
            [Blob("thumbs/s-{name}", FileAccess.Write, Connection = "StorageConnection")] Stream imageSmall,
        TraceWriter log)
        {
            var img = Image.FromStream(picture);
            var thumb = img.GetThumbnailImage(200, 320,()=>false, IntPtr.Zero);
        }
    }
}
