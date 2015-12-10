using Dropbox.Api;
using Dropbox.Api.Files;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Utilities
{
    class Helper
    {
        static ILog log = LogManager.GetLogger(typeof(Helper));
        public static async Task<bool> UploadAsync(Image doc, string dropfilePath)
        {
            string tempfileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
            doc.Save(tempfileName);

            using (var mem = new FileStream(tempfileName, FileMode.Open))
            {
                //todo: shift and fetch from passsword-appconfig;
                DropboxClient dbx = new DropboxClient("E-9ylJ5wcN0AAAAAAAAQKaAbks3oqnG3NwawDf3AsT9i8HZf0YeXHqd6p8fFjCYi");
                try
                {
                    var updated = await dbx.Files.UploadAsync(dropfilePath, WriteMode.Overwrite.Instance, body: mem).ConfigureAwait(false);
                    return true;
                }
                catch (ApiException<UploadError> apiEx)
                {
                    log.Error(apiEx);
                    return false;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> DeleteDocumentAsync(string dropfilePath, string _ID)
        {
            //todo: shift and fetch from passsword-appconfig;
            DropboxClient dbx = new DropboxClient("E-9ylJ5wcN0AAAAAAAAQKaAbks3oqnG3NwawDf3AsT9i8HZf0YeXHqd6p8fFjCYi");
            try
            {
                var searchValue = await dbx.Files.SearchAsync(dropfilePath, _ID);
                if (searchValue.Matches.Count > 0)
                    await dbx.Files.DeleteAsync(string.Format("{0}/{1}.png", dropfilePath, _ID));
                return true;
            }
            catch (ApiException<UploadError> apiEx)
            {
                log.Error(apiEx);
                return false;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static async Task<Image> GetDocumentAsync(string dropfilePath, string _ID)
        {
            //todo: shift the key to passConfig
            using (DropboxClient dbx = new DropboxClient("E-9ylJ5wcN0AAAAAAAAQKaAbks3oqnG3NwawDf3AsT9i8HZf0YeXHqd6p8fFjCYi"))
            {
                try
                {
                     var searchValue = await dbx.Files.SearchAsync(dropfilePath, _ID);
                     if (searchValue.Matches.Count > 0)
                     {
                         var downloadedFileResponse = await dbx.Files.DownloadAsync(string.Format("{0}/{1}.png", dropfilePath, _ID));
                         var downloadedFileStream = await downloadedFileResponse.GetContentAsStreamAsync();
                         return Image.FromStream(downloadedFileStream);
                     }
                }
                catch (ApiException<DownloadError> apiEx)
                {
                    log.Error(apiEx);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            return null;
        }
    }
}
