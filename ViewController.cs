using System;

using UIKit;

namespace BMICalculator
{
    public partial class ViewController : UIViewController
    {
        float bmi = 21.5f;
        public ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            calculateButton.TouchUpInside+= CalculateButton_TouchUpInside;
        }

        void CalculateButton_TouchUpInside(object sender, EventArgs e)
        {
            var height = float.Parse(heightTextField.Text);
            var weight = float.Parse(weightTextField.Text);

            bmi = (weight / (height * height));

            bmiLabel.Text = bmi.ToString();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var detailViewController = segue.DestinationViewController as DetailViewController;

            detailViewController.bmi = this.bmi;
        }
    }
}
