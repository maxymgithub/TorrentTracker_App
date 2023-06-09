﻿using AltoHttp;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TorrentTracker_App
{
    [AddINotifyPropertyChangedInterface]
    public class CurrentTorrentFile
    {
        public HttpDownloader httpDownloader;
        public string Name { get; set; }
        public double Size { get; set; }
        public string Speed { get; set; }
        public double DownloadProgress { get; set; }

        public void HttpDownloader_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            Size = Math.Round(httpDownloader.Info.Length / 1024d / 1024d, 2, MidpointRounding.AwayFromZero);
            DownloadProgress = e.Progress;
            Speed = $"{(e.SpeedInBytes / 1024d / 1024d).ToString("0.00")} MB/s";
        }
        public void HttpDownloader_DownloadCompleted(object? sender, EventArgs e)
        {
            MessageBox.Show("Download Completed!");
        }
    }
}
