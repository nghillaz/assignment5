using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5.Staff
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //user has no session, needs to login, send them to that page
            if (Session["Sid"] == null || Session["isAdmin"] == null || Session["isAdmin"].ToString() != "true")
            {
                Response.Redirect("~/StaffLogin");
            }
            //if the user has a session, they've successfully logged in and should be allowed on the page
            //also display their username at the top of the page
            else
            {
                UsernameLabel.Text = "Welcome back, " + Session["Username"].ToString();
            }
        }

        protected void WeatherButton_Click(object sender, EventArgs e)
        {
            WeatherService.IWeatherService weatherService = new WeatherService.WeatherServiceClient();
            string zipcode = WeatherZipCodeTextBox.Text;
            string units = WeatherUnitsTextBox.Text;
            string[] forcast= weatherService.getForcast(zipcode, units);
            for(int i = 0; i != forcast.Length; i++)
            {
                ForcastLabel.Text +=  forcast[i] + "<br>";
            }
            LocationOutLabel.Text = weatherService.getLocation(zipcode);
        }

        protected void GetStoresButton(object sender, EventArgs e)
        {
            StoreLocationService.IStoreLocationService storelocationService = new StoreLocationService.StoreLocationServiceClient();
            string term = SearchTermTextBox.Text;
            string location = StoresLocationTextBox.Text;
            string[] stores = storelocationService.QueryYelpAPI(term, location);
            for (int i = 0; i != stores.Length; i++)
            {
                LocalStoresOutputLabel.Text += stores[i] + "<br>";
            }
        }

        protected void RatingButton_Click(object sender, EventArgs e)
        {
            StoreRatingService.IStoreRatingService storeRatingService = new StoreRatingService.StoreRatingServiceClient();
            string storeName = StoreNameRatingTextBox.Text;
            string storeLocation = StoreLocationRatingTextBox.Text;
            string[] ratings = storeRatingService.QueryYelpAPI(storeName, storeLocation);
            for (int i = 0; i != ratings.Length; i++)
            {
                RatingLabel.Text += ratings[i] + "<br>";
            }
        }
    }
}