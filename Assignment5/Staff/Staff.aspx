<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment5.Staff.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="row">
        <div class="col-md-8">
            <h2> Welcome to the Staff Page</h2>
            <h3>
                <asp:Label ID="UserNameLabel" runat="server" Text=""></asp:Label></h3>
            <h5>You have access to the following tools!</h5>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h4>Get Local Weather via WeatherService!</h4>
            <p>
                Find the local weather!<br />
                Enter in the zipcode you want the weather for: 
                <asp:TextBox ID="WeatherZipCodeTextBox" runat="server"></asp:TextBox><br />
                Enter in the Units([case sensitive] imperial or  metric):
                <asp:TextBox ID="WeatherUnitsTextBox" runat="server"></asp:TextBox> <br /> 
                <asp:Button ID="GetWeatherButton" runat="server" Text="Get Weather" OnClick="WeatherButton_Click" />
                <br />
                <asp:Label ID="ForcastLabel" runat="server" Text=""></asp:Label>
                <br />
                <br />
                FOR The Area OF: 
                <asp:Label ID="LocationOutLabel" runat="server" Text=""></asp:Label>
        </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h4>Find the location of your favorite stores via StoreLocationService!</h4>
             <p>
                This service takes in a search term and a location name eg (wine; Tempe, AZ)               
            </p>
            <p>
                Find the 5 closest stores for specific type of shopping or dining you want <br />
                Enter in the term:   
                <asp:TextBox ID="SearchTermTextBox" runat="server"></asp:TextBox><br />
                Enter in the location:  
                <asp:TextBox ID="StoresLocationTextBox" runat="server"></asp:TextBox><br />
                <asp:Button ID="GetLocalStoresButton" runat="server" Text="Get Stores" OnClick="GetStoresButton" />
                <br />
            </p>
            <p>
                The top 5 stores are: <br />  
                <asp:Label ID="LocalStoresOutputLabel" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h4> Discover how well a store is doing before you head there via StoreRatingService!</h4>
                <p>
                Enter in a store and location you want to see the rating of:  <br />
                Store Name:  <asp:TextBox ID="StoreNameRatingTextBox" runat="server"></asp:TextBox><br />
                Store Location:  <asp:TextBox ID="StoreLocationRatingTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="RatingButton" runat="server" Text="GetRating" OnClick="RatingButton_Click" />
                <br />
            </p>
            <p>
                The Store ratings are: <br />
                <asp:Label ID="RatingLabel" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>
    <div class="row2">
        <div class="col-mid-8">
            <h4> Want to keep track of which stores you have visited.  Use the StoreCheckInService!</h4>
             <p>               
                Store Name: <asp:TextBox ID="StoreNameCheckInTextBox" runat="server"></asp:TextBox><br />
                Store Location:  <asp:TextBox ID="StoreLocationCheckInTextBox" runat="server"></asp:TextBox><br />
                <asp:Button ID="CheckInButton" runat="server" Text="CheckIn" OnClick="CheckInButton_Click" /><br />
               
                Lets see where you have been!! <br />
                <asp:Button ID="ListStoresButton" runat="server" Text="List Stores" OnClick="ListStoresButton_Click" /><br />
                Visited Stores are: <br />
                <asp:Label ID="ListPlacesVisitedLabel" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>

</asp:Content>
