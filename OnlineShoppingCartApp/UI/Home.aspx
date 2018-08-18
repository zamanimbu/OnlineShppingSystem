<%@ Page Language="C#" MasterPageFile="main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineShoppingCartApp.UI.Home" %>

<asp:Content runat="server" ContentPlaceHolderID="carouselContentPlaceHolder">
         <!-- Carousel-->
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="../Image/Carousel/1.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>Gucci Backpack </h3>
                            <p>Life Style Accessories</p>
                            <p><a class="btn btn-lg btn-primary" href="#" role="button">Join Us Today</a></p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="../Image/Carousel/2.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>Your Ultimate Shopping solution</h3>
                            <p>Boost-Up your shoping experience</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="../Image/Carousel/3.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>Ask more of your brand</h3>
                            <p>Pixel 2</p>
                        </div>
                    </div>
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        <!--Caorusel-->
        <div>
            <div class="container center">
                <div class="row">
                    <div class="col-lg-4">
                        <img class="img-circle" src="../Image/middleArea/2.jpg" alt="thumb01" width="140" height="140" />
                        <h2>Shopping bt tapping</h2>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting,</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-circle" src="../Image/middleArea/1.jpg" alt="thumb02" width="140" height="140" />
                        <h2>All valuable Brand </h2>
                        <p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. </p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-circle" src="../Image/middleArea/3.jpg" alt="thumb03" width="140" height="140" />
                        <h2>All fashion Accessories</h2>
                        <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text</p>
                        <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="scriptContent">
    <script>
        $('#signOutButtonMasterPage').hide();
        $(document).ready(function () {
            $('.carousel').carousel({
                interval: 3000
            });
        });
    </script> 
</asp:Content>

