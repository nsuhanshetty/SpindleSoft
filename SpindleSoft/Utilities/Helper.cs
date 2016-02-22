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
using System.Configuration;

namespace SpindleSoft.Utilities
{
    class Helper
    {

        static string baseDoc = ConfigurationManager.AppSettings["BaseDocDirectory"];
        static string CustomerImagePath = ConfigurationManager.AppSettings["CustomerImages"];

        static ILog log = LogManager.GetLogger(typeof(Helper));
        public static async Task<bool> UploadToWebAsync(Image doc, string dropfilePath)
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

        public static bool UploadToLocal(Image doc, string fileName)
        {
            try
            {
                bool _fileExists = File.Exists(fileName);
                if (_fileExists)
                    File.Delete(fileName);
                doc.Save(fileName);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static async Task<bool> DeleteDocumentWebAsync(string dropfilePath, string _ID)
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

        //public static async Task<bool> DeleteDocumentLocal(string dropfilePath, string _ID)
        //{
        //    try
        //    {
        //        var searchValue = await dbx.Files.SearchAsync(dropfilePath, _ID);
        //        if (searchValue.Matches.Count > 0)
        //            await dbx.Files.DeleteAsync(string.Format("{0}/{1}.png", dropfilePath, _ID));
        //        return true;
        //    }
        //    catch (ApiException<UploadError> apiEx)
        //    {
        //        log.Error(apiEx);
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        return false;
        //    }
        //}

        public static bool DeleteDocumentLocal(string _fileName)
        {
            try
            {
                bool _fileExists = File.Exists(_fileName);
                if (_fileExists)
                    File.Delete(_fileName);

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

        public static async Task<Image> GetDocumentWebAsync(string dropfilePath, string _ID)
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

        public static Image GetDocumentLocal(string _fileName)
        {
            try
            {
                Image _image = null;
                bool _fileExists = File.Exists(_fileName);
                if (_fileExists)
                {
                    using (var stream =
                        new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        _image = Image.FromStream(stream);
                    }
                }
                return _image;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
    }
}
