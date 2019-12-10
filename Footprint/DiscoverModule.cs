using System;
using UIKit;
using Foundation;

namespace Footprint
{
    public class DiscoverModule
    {
        public string Header;
        public string secondaryHeader;

        public UINavigationController mainController;

        public UICollectionView uicollectionView;

        public UIButton expandButton;

        public void setController(UINavigationController controller)
        {
            mainController = controller;
        }

        public virtual async void asyncInitilize()
        {

        }

        public virtual void itemSelected(NSIndexPath indexPath)
        {

        }

        public virtual void collectionViewAssigned()
        {

        }

        public virtual UIImage getImage(NSIndexPath indexPath)
        {
            return UIImage.FromFile("Image/Challenge/FoodPrice.png");
        }

        public virtual string getName(NSIndexPath indexPath)
        {
            return "PlaceHolder Name";
        }

        public virtual string getDescription(NSIndexPath indexPath)
        {
            return "PlaceHolder Description";
        }

        public virtual int getRowCount()
        {
            return 10;
        }

        public virtual int getColorCode(NSIndexPath indexPath)
        {
            return 0;
        }

        public virtual bool addButtomVisibility()
        {
            return true;
        }

        public virtual bool secondaryHeaderVisibility()
        {
            return false;
        }

        public virtual bool expansionButtonVisibility()
        {
            return true;
        }
    }
}
