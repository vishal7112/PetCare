<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BusyPet._Default" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--<div class="row">
        <div class="col-lg-12">
            <div class="jumbo card">
                <h1>News</h1>
                <p class="lead">Happy coding, friends!</p>
            </div>
        </div>
    </div>-->

    <div class="row">

        <div class="col col-md-8 card">
            <div class="row">
                <div class="col-lg-12">
                    <h1>Track Your Pet's Health</h1>
                    <p>What is this website?</p>
                    <p>Brief summary here</p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean vehicula, justo id tincidunt semper, ipsum metus vestibulum tortor, sit amet volutpat ipsum ligula vitae justo. Nulla at metus elit. Nam sit amet diam sit amet lorem finibus fermentum. Mauris ac erat ut nisl commodo pharetra. Curabitur velit nisi, mollis sit amet nibh at, porttitor egestas ex. Nam tellus ex, tristique et orci eu, fermentum iaculis eros. Suspendisse condimentum ultrices nisi et suscipit. Vivamus aliquam placerat nulla, ut consectetur massa rutrum sed. Praesent blandit risus ac diam accumsan, quis faucibus nibh pharetra. Nulla facilisis diam eget rhoncus tristique. Cras tincidunt magna in nunc elementum finibus. Maecenas ullamcorper nibh quis placerat blandit. Nullam at nisi quis mi fringilla interdum et vitae purus. Duis feugiat nisi ac justo ornare pellentesque.</p>
                    <p>
                        Sed ac iaculis sapien. Nunc eu enim tristique, porta mauris sit amet, accumsan ipsum. Mauris porta, enim et accumsan semper, eros nisl rutrum velit, a lacinia tortor dui sit amet est. Mauris convallis dapibus erat, vitae pharetra nunc congue ut. Pellentesque fermentum pellentesque libero vitae tempor. Aliquam vestibulum, augue sed consectetur faucibus, mi massa condimentum dolor, et iaculis purus risus sed ligula. Nunc vel tempor quam. Nam in varius nisl, vel convallis nisi.
                    </p>
                    <p>
                        Suspendisse potenti. Nam aliquam sapien quis auctor eleifend. Aenean faucibus volutpat purus. Donec sit amet finibus lacus. Morbi vulputate pharetra facilisis. Pellentesque in gravida augue. Donec ac metus nec ligula lacinia maximus. Aliquam dictum dui id varius dignissim.
                    </p>
                    <p>
                        Donec accumsan, nunc et euismod euismod, erat ex tincidunt orci, et vulputate sem lectus vehicula ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam ut luctus metus. In porttitor venenatis est eget lobortis. Vestibulum interdum dolor eget nisi aliquet, vitae tincidunt turpis molestie. Nullam suscipit porttitor felis, a euismod metus accumsan a. Proin facilisis nulla vel massa tempus dictum. Ut risus metus, varius non tincidunt vitae, euismod ut sem. Proin non sodales neque. Quisque vulputate hendrerit auctor. Etiam nec semper lectus, ut consequat arcu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet ante semper, euismod enim non, fermentum erat.
                    </p>
                    <a>Learn more...</a>
                </div>
            </div>
        </div>

        <div class="col col-md-4 card">

            <div class="div-content">
                <div class="row">
                    <div class="col-lg-12">
                        <h2>New to BusyPet?</h2>
                        <a href="SignUp.aspx">
                            <p>Let's get started!</p>
                        </a>
                    </div>
                </div>
            </div>

            <div class="div-content">
                <div class="row">
                    <div class="col-lg-12">
                        <h2>Sign In</h2>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <input type="email" placeholder="Email Address" runat="server" id="emailTextBox" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <input type="password" placeholder="Password" runat="server" id="passwordTextBox" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <p><a>Forgot Password?</a></p>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <button runat="server" class="btn btn-primary" value="Sign In" onserverclick="SignIn_SubmitBtnClick">Sign In</button>
                    </div>
                </div>
            </div>

            <div class="div-content">
                <div class="row">
                    <div class="col-lg-12">
                        <h2>Follow Us</h2>
                        <ul class="ul-no-decoration">
                            <li class="li-no-decoration">
                                <a>
                                    <p>Social Media</p>
                                </a>
                            </li>
                            <li class="li-no-decoration">
                                <a>
                                    <p>Social Media</p>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
