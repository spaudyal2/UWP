using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SubitPaudyal_Lab4                                 //Subit Paudyal Section 3- Lab 4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void radCuboid_Checked(object sender, RoutedEventArgs e) //the below things will enable and disbale when the cuboid radio button is selected.
        {
            txtUserLength.IsEnabled = true; // true = enabled- user can only input values in these textbox to calculate the result.
            txtUserWidth.IsEnabled = true;
            txtUserHeight.IsEnabled = true;
            txtUserRadius.IsEnabled = false; // false = disabled- user cannot input anything in this text box.

            txtUserRadius.Text = "0"; //inputing 0 automatically when the field is disbaled for easier calulation.
            txtUserLength.Text = "";  //this is where user inputs value for calculation for cuboid.
            txtUserWidth.Text = "";
            txtUserHeight.Text = "";

            txtResultVolume.Text = ""; // making the results for volume and surface area to empty automatically when the different radiobutton is checked.
            txtResultSurface.Text = "";
        }

        private void radSphere_Checked(object sender, RoutedEventArgs e) // the below things will enable and disbale when the sphere radio button is selected.
        {
            txtUserLength.IsEnabled = false; // false = disabled- user cannot input anything in this text box.
            txtUserWidth.IsEnabled = false;
            txtUserHeight.IsEnabled = false;
            txtUserRadius.IsEnabled = true; // true = enabled- user can only input values in these textbox to calculate the result.

            txtUserLength.Text = "0"; // same as above, inputing 0 automatically when the field is disbaled for easier calulation.
            txtUserWidth.Text = "0";
            txtUserHeight.Text = "0";
            txtUserRadius.Text = ""; // same as above, this is where user inputs value for calculation for cuboid.

            txtResultVolume.Text = ""; //making the result for volume and surface area to empty automatically when the different radiobutton is checked.
            txtResultSurface.Text = "";
        }

        private void radCylinder_Checked(object sender, RoutedEventArgs e) // the below things will enable and disbale when the cylinder radio button is selected.
        {
            txtUserLength.IsEnabled = false; //false = disabled- user cannot input anything in this text box.
            txtUserWidth.IsEnabled = false;
            txtUserHeight.IsEnabled = true;
            txtUserRadius.IsEnabled = true; // true = enabled- user can only input values in these textbox to calculate the result.

            txtUserLength.Text = "0"; //just like the above 2, inputing 0 automatically when the field is disbaled for easier calulation.
            txtUserWidth.Text = "0";
            txtUserHeight.Text = "";
            txtUserRadius.Text = "";  // just like the above 2, this is where user inputs value for calculation for cuboid.

            txtResultVolume.Text = ""; // making the result for volume and surface area to empty automatically when the different radiobutton is checked.
            txtResultSurface.Text = "";
        }

        private void btnCalculateVolumeClick(object sender, RoutedEventArgs e) // when the user clicks on "Calculate Volume" button.
        {
            try
            {
                calculateVolume(); //this will call the function from below called "calculateVolume()"
            }
            catch (Exception caught)
            {
                txtResultVolume.Text = caught.Message; // and whatever is calculated is outputted for user to see on the result box for volume.
            }

        }

        private void btnCalculateSurfaceClick(object sender, RoutedEventArgs e) // when the user clicks on "Calculate Surface Area" button.
        {
            
            try
            {
                 calculateSurface(); //this will call the function from below called "calculateSurface()"
            }
            catch (Exception caught)
            {
                txtResultSurface.Text = caught.Message; // and whatever is calculated is outputted for user to see on the result box for volume.
            }

        }
        

        private void calculateVolume()  // when user clicks on "Calculate Volume" button 
        {
            double length = double.Parse(txtUserLength.Text); //converting the user input from length text box to double data type.
            double width = double.Parse(txtUserWidth.Text);   //converting the user input from width text box to double data type.
            double height = double.Parse(txtUserHeight.Text); //converting the user input from height text box to double data type.
            double radius = double.Parse(txtUserRadius.Text); //converting the user input from radius text box to double data type.
            double Pi = 3.14;                              // assigning value of 3.14 to PI
            
            double outcome = 0;
            
            if ((bool)radCuboid.IsChecked)
            {
                outcome = length * width * height;  //(l*w*h)       this formula is called when the user selects "cuboid" radio button and has inputed required field for calc.
                txtResultVolume.Text = Math.Round(outcome, 2).ToString(); //once the calculation is done, the result is rounded to 2 decimal and convert it to string for user to view the result.
            } 
            if ((bool)radSphere.IsChecked)
            {
                outcome = (4 * Pi * radius * radius * radius)/3;    //(4/3*π*r^3)     this formula is called when the user selects "sphere" radio button and has inputed required field for calc.
                txtResultVolume.Text = Math.Round(outcome, 2).ToString(); //once the calculation is done, the result is rounded to 2 decimal and convert it to string for user to view the result.
            }
            if ((bool)radCylinder.IsChecked)
            {
                outcome = ( Pi * (radius * radius) * height);   //(π*r^2*h)     this formula is called when the user selects "cylinder" radio button and has inputed required field for calc.
                txtResultVolume.Text = Math.Round(outcome, 2).ToString(); //once the calculation is done, the result is rounded to 2 decimal and convert it to string for user to view the result.
            }
            
                                  
        }
        private void calculateSurface() // similar as above but now its when user clicks on "Calculate Surface Area" button.
        {
            double length = double.Parse(txtUserLength.Text);
            double width = double.Parse(txtUserWidth.Text);
            double height = double.Parse(txtUserHeight.Text);
            double radius = double.Parse(txtUserRadius.Text);
            double Pi = 3.14;

            double outcome = 0;

            if ((bool)radCuboid.IsChecked)
            {
                outcome = (2 * length * width) + (2 * length * height) + (2 * height * width);  //formula to calculate Surface area of cuboid. (2*l*w)+(2*l*h)+(2*h*w)
                txtResultSurface.Text  = Math.Round(outcome, 2).ToString();
            }
            if ((bool)radSphere.IsChecked)
            {
                outcome = 4 * Pi * (radius * radius);   //formula to calculate Surface area of sphere. (4*π*r^2)
                txtResultSurface.Text = Math.Round(outcome, 2).ToString();
            }
            if ((bool)radCylinder.IsChecked)
            {
                outcome = (2 * Pi * radius * height) + (2 * Pi * (radius * radius));    //formula to calculate Surface area of cylinder. ((2*π*r*h)+(2*π*r^2)
                txtResultSurface.Text = Math.Round(outcome, 2).ToString();
            }
        }
    }
}
