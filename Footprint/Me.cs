using System;
using Foundation;
using UIKit;
using System.IO;
using Footprint.Base.lproj;

//to be removed


namespace Footprint
{
	public partial class Me : UIViewController
	{

        UIImagePickerController picker;

        public Me (IntPtr handle) : base (handle)
		{

		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var tableCell = new JustTableViewSource(this);
            Table.Source = tableCell;

            username.AdjustsFontSizeToFitWidth = true;

            if(Filewrite.LoadUsername() != null)
            {
                username.Text = Filewrite.LoadUsername();
            }
            else
            {
                username.Text = NSBundle.MainBundle.GetLocalizedString("Your Name");
            }

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Profile.jpg"))
            {
                ProfilePic.Image = Filewrite.LoadAvatar();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("SomethingExists");
                ProfilePic.Image = UIImage.FromFile("Image/Me_Icons/Avatar_Null.png");
            }
        }

        partial void ProfileTap(NSObject sender)
        {
            System.Diagnostics.Debug.WriteLine("Tapped");

            picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            picker.FinishedPickingMedia += Finished;
            picker.Canceled += Canceled;
            PresentViewController(picker, animated: true, completionHandler: null);
        }

        partial void changeUsername(NSObject sender)
        {
            System.Diagnostics.Debug.WriteLine("submtiing");

            UsernameChange us = this.Storyboard.InstantiateViewController("Username") as UsernameChange;
            us.me = this;
            var usernameChange_NavigationalBar = new UINavigationController(us);
            this.NavigationController.PresentModalViewController(usernameChange_NavigationalBar, true);

        }

        public void Finished(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            bool isImage = false;
            switch (e.Info[UIImagePickerController.MediaType].ToString())
            {
                case "public.image":
                    isImage = true;
                    break;
                case "public.video":
                    break;
            }
            NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
            if (referenceURL != null) Console.WriteLine("Url:" + referenceURL.ToString());
            if (isImage)
            {
                UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImage != null)
                {
                    ProfilePic.Image = originalImage;
                    Filewrite.UpdateAvatar(originalImage);
                }
            }
            else
            {
                NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
                if (mediaURL != null)
                {
                    Console.WriteLine(mediaURL.ToString());
                }
            }
            picker.DismissModalViewController(true);
        }

        void Canceled(object sender, EventArgs e)
        {
            picker.DismissModalViewController(true);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.  
        }

        partial void NameTap(NSObject sender)
        {
            
        }


        public void SubmitUsernameChange(string name)
        {
            Filewrite.UpdateUsername(name);
            username.Text = name;
        }

        partial void survey(NSObject sender)
        {
            SurveyMenu surveyMenu = this.Storyboard.InstantiateViewController("SurveyMenu") as SurveyMenu;
            this.NavigationController.PushViewController(surveyMenu, true);

            /*
            SurveyView surveyView = this.Storyboard.InstantiateViewController("SurveyView") as SurveyView;
            var surveyController = new UINavigationController(surveyView);
            var surveyClass = new SurveyClass("debug.xml");
            surveyClass.Start(surveyView);
            surveyView.me = this;
            this.NavigationController.PresentViewController(surveyController, true, null);*/
        }
    }
}
