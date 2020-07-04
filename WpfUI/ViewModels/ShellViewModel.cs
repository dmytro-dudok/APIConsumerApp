using WpfUI.Library;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Library.Api;
using App.Library.Models;
using WpfUI.Helpers;

namespace WpfUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly IFoxProcessor _foxProcessor;
        private readonly IFoxImageEndpoint _foxImageEndpoint;
        private string foxImageUrl;
        private string title;

        public ShellViewModel(IFoxProcessor foxProcessor, IFoxImageEndpoint foxImageEndpoint)
        {
            _foxProcessor = foxProcessor;
            _foxImageEndpoint = foxImageEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

                await LoadImage();
        }

        public async Task LoadImage()
        {
            try
            {
                var imageUrl = await _foxProcessor.LoadRandomFox();

                FoxImageUrl = imageUrl.Image;

                Title = "";

                log.Info("Image loaded");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

           
        }

        public string FoxImageUrl
        {
            get => foxImageUrl;
            set
            {
                foxImageUrl = value;
                NotifyOfPropertyChange(() => FoxImageUrl);
            }
        }

        public void SaveToDatabase()
        {

            try
            {
                var item = new FoxImageModel { ImageLink = FoxImageUrl, Title = Title };

                _foxImageEndpoint.SaveFoxImage(item);

                log.Info("Image saved");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public string Title
        {
            get => title; 
            set
            {
                title = value;

                NotifyOfPropertyChange(() => Title);
            }
        }

    }
}
