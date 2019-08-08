<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="video-distributions-calculator.aspx.cs" Inherits="videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="alternate" href="https://Agrimetsoft.com/distributions-calculator/video-distributions-calculator.aspx" hreflang="en-us" />
    <link rel="canonical" href="https://Agrimetsoft.com/distributions-calculator/video-distributions-calculator.aspx" />

    <meta name="keywords" content="video distributions calculator " />
    <meta name="description" content="It is the videos to help for online tools for calculating and fitting the proablity of a value of distributions. All these videos are located in a YouTube Playlist." />

    <!-- bootstrap -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <!-- styles -->
    <style>
        body { margin: 0px !important; }
        .video { margin: 10px 0px; }
        .video .title { font-weight: normal; white-space: nowrap; overflow: hidden; }
        .video .thumbnail img { width: 288px; height: 216px; }
        .descrip {margin:0;padding:5px;align-content:stretch;content:box;font-family:Tahoma;font-size:12px}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

        <!-- placeholder where we will render the results -->
        <asp:PlaceHolder ID="pnlVideos" runat="server" />
        <div style="padding-top: 10px">
            <asp:Label ID="lblMessage" Font-Bold="true" ForeColor="Red" ClientIDMode="Static" runat="server" />
        </div>
        <!-- template to help build each video container -->
        <asp:Literal ID="lblTemplate" Visible="false" runat="server">
            <div class="video col-lg-6">
                <div class="title">
                    <a href="{Url}" target="_blank">
                        {Title}
                    </a>
                </div>
                <div class="thumbnail">
                    <a title="{ToolTip}" href="{Url}" target="_blank">
                        <img title="{ToolTip}" src="{Image}" alt="{Alt}" />
                    </a>
                    <p class="descrip">{Description}</p>
                </div>
            </div>
        </asp:Literal>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

