﻿using Infrastructure.DirectoryManager;
using Infrastructure.EgmaCV;
using Infrastructure.FileManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebCamImageSync
{
    public class Application
    {
        private readonly IEgmaCvAdapter _egmaCvAdapter;
        private readonly IFileManagerService _fileManagerService;
        private readonly IDirectoryManagerService _directoryManagerService;

        public Application(IEgmaCvAdapter egmaCvAdapter, 
            IFileManagerService fileManagerService,
            IDirectoryManagerService directoryManagerService)
        {
            _egmaCvAdapter = egmaCvAdapter;
            _fileManagerService = fileManagerService;
            _directoryManagerService = directoryManagerService;
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("Capturing image");
                
                var fileName = $"{Guid.NewGuid()}.jpg";
                var filePath = _directoryManagerService.CreateProgramDataFilePath("WebCamSync", fileName);

                _egmaCvAdapter.CaptureImage(0, filePath);

                Console.WriteLine("Done");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
