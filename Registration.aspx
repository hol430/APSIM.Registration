<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ProductRegistration.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APSIM Initiative Product Registration</title>
    <link rel="stylesheet" media="screen" href="Screen_Styles.css" type="text/css" />
    <style type="text/css">
       #form1
       {
          height: 565px;
       }
    </style>
</head>
<body>
   <h1>
      APSIM Initiative Product Registration
   </h1>
   To download software you must complete the registration form below. All fields marked with an asterisk (*) are mandatory.
    <form id="form1" runat="server">
      <asp:Label ID="ErrorLabel" runat="server" Font-Bold="True" ForeColor="#FF3300" 
         Visible="False"></asp:Label>
      <asp:Table 
         ID="Table1" runat="server" Height="500px" Width="836px"
         EnableTheming="True">
         <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server">Product to download*:</asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server"><asp:DropDownList ID="Product" runat="server" Width="200px" AutoPostBack="True"/></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell ID="VersionLabel" runat="server"> </asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList ID="Version" runat="server" Width="200px"></asp:DropDownList></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server"> </asp:TableCell>
            <asp:TableCell runat="server"> </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">First name:*</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="FirstName" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Last name*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="LastName" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Organisation*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Organisation" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Address 1*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Address1" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Address 2:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Address2" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">City/Location*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="City" runat="server" Width="200px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">State/Provence:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="State" runat="server" Width="200px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Postcode/Zipcode*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Postcode" runat="server" Width="200px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Country*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList ID="Country" runat="server" Width="200px">
                  <asp:ListItem Value=""></asp:ListItem>
                  <asp:ListItem Value="Afganistan">Afghanistan</asp:ListItem>
                  <asp:ListItem Value="Albania">Albania</asp:ListItem>
                  <asp:ListItem Value="Algeria">Algeria</asp:ListItem>
                  <asp:ListItem Value="American Samoa">American Samoa</asp:ListItem>
                  <asp:ListItem Value="Andorra">Andorra</asp:ListItem>
                  <asp:ListItem Value="Angola">Angola</asp:ListItem>
                  <asp:ListItem Value="Anguilla">Anguilla</asp:ListItem>
                  <asp:ListItem Value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</asp:ListItem>
                  <asp:ListItem Value="Argentina">Argentina</asp:ListItem>
                  <asp:ListItem Value="Armenia">Armenia</asp:ListItem>
                  <asp:ListItem Value="Aruba">Aruba</asp:ListItem>
                  <asp:ListItem Value="Australia">Australia</asp:ListItem>
                  <asp:ListItem Value="Austria">Austria</asp:ListItem>
                  <asp:ListItem Value="Azerbaijan">Azerbaijan</asp:ListItem>
                  <asp:ListItem Value="Bahamas">Bahamas</asp:ListItem>
                  <asp:ListItem Value="Bahrain">Bahrain</asp:ListItem>
                  <asp:ListItem Value="Bangladesh">Bangladesh</asp:ListItem>
                  <asp:ListItem Value="Barbados">Barbados</asp:ListItem>
                  <asp:ListItem Value="Belarus">Belarus</asp:ListItem>
                  <asp:ListItem Value="Belgium">Belgium</asp:ListItem>
                  <asp:ListItem Value="Belize">Belize</asp:ListItem>
                  <asp:ListItem Value="Benin">Benin</asp:ListItem>
                  <asp:ListItem Value="Bermuda">Bermuda</asp:ListItem>
                  <asp:ListItem Value="Bhutan">Bhutan</asp:ListItem>
                  <asp:ListItem Value="Bolivia">Bolivia</asp:ListItem>
                  <asp:ListItem Value="Bonaire">Bonaire</asp:ListItem>
                  <asp:ListItem Value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</asp:ListItem>
                  <asp:ListItem Value="Botswana">Botswana</asp:ListItem>
                  <asp:ListItem Value="Brazil">Brazil</asp:ListItem>
                  <asp:ListItem Value="British Indian Ocean Ter">British Indian Ocean Ter</asp:ListItem>
                  <asp:ListItem Value="Brunei">Brunei</asp:ListItem>
                  <asp:ListItem Value="Bulgaria">Bulgaria</asp:ListItem>
                  <asp:ListItem Value="Burkina Faso">Burkina Faso</asp:ListItem>
                  <asp:ListItem Value="Burundi">Burundi</asp:ListItem>
                  <asp:ListItem Value="Cambodia">Cambodia</asp:ListItem>
                  <asp:ListItem Value="Cameroon">Cameroon</asp:ListItem>
                  <asp:ListItem Value="Canada">Canada</asp:ListItem>
                  <asp:ListItem Value="Canary Islands">Canary Islands</asp:ListItem>
                  <asp:ListItem Value="Cape Verde">Cape Verde</asp:ListItem>
                  <asp:ListItem Value="Cayman Islands">Cayman Islands</asp:ListItem>
                  <asp:ListItem Value="Central African Republic">Central African Republic</asp:ListItem>
                  <asp:ListItem Value="Chad">Chad</asp:ListItem>
                  <asp:ListItem Value="Channel Islands">Channel Islands</asp:ListItem>
                  <asp:ListItem Value="Chile">Chile</asp:ListItem>
                  <asp:ListItem Value="China">China</asp:ListItem>
                  <asp:ListItem Value="Christmas Island">Christmas Island</asp:ListItem>
                  <asp:ListItem Value="Cocos Island">Cocos Island</asp:ListItem>
                  <asp:ListItem Value="Colombia">Colombia</asp:ListItem>
                  <asp:ListItem Value="Comoros">Comoros</asp:ListItem>
                  <asp:ListItem Value="Congo">Congo</asp:ListItem>
                  <asp:ListItem Value="Cook Islands">Cook Islands</asp:ListItem>
                  <asp:ListItem Value="Costa Rica">Costa Rica</asp:ListItem>
                  <asp:ListItem Value="Cote DIvoire">Cote D'Ivoire</asp:ListItem>
                  <asp:ListItem Value="Croatia">Croatia</asp:ListItem>
                  <asp:ListItem Value="Cuba">Cuba</asp:ListItem>
                  <asp:ListItem Value="Curaco">Curacao</asp:ListItem>
                  <asp:ListItem Value="Cyprus">Cyprus</asp:ListItem>
                  <asp:ListItem Value="Czech Republic">Czech Republic</asp:ListItem>
                  <asp:ListItem Value="Denmark">Denmark</asp:ListItem>
                  <asp:ListItem Value="Djibouti">Djibouti</asp:ListItem>
                  <asp:ListItem Value="Dominica">Dominica</asp:ListItem>
                  <asp:ListItem Value="Dominican Republic">Dominican Republic</asp:ListItem>
                  <asp:ListItem Value="East Timor">East Timor</asp:ListItem>
                  <asp:ListItem Value="Ecuador">Ecuador</asp:ListItem>
                  <asp:ListItem Value="Egypt">Egypt</asp:ListItem>
                  <asp:ListItem Value="El Salvador">El Salvador</asp:ListItem>
                  <asp:ListItem Value="Equatorial Guinea">Equatorial Guinea</asp:ListItem>
                  <asp:ListItem Value="Eritrea">Eritrea</asp:ListItem>
                  <asp:ListItem Value="Estonia">Estonia</asp:ListItem>
                  <asp:ListItem Value="Ethiopia">Ethiopia</asp:ListItem>
                  <asp:ListItem Value="Falkland Islands">Falkland Islands</asp:ListItem>
                  <asp:ListItem Value="Faroe Islands">Faroe Islands</asp:ListItem>
                  <asp:ListItem Value="Fiji">Fiji</asp:ListItem>
                  <asp:ListItem Value="Finland">Finland</asp:ListItem>
                  <asp:ListItem Value="France">France</asp:ListItem>
                  <asp:ListItem Value="French Guiana">French Guiana</asp:ListItem>
                  <asp:ListItem Value="French Polynesia">French Polynesia</asp:ListItem>
                  <asp:ListItem Value="French Southern Ter">French Southern Ter</asp:ListItem>
                  <asp:ListItem Value="Gabon">Gabon</asp:ListItem>
                  <asp:ListItem Value="Gambia">Gambia</asp:ListItem>
                  <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
                  <asp:ListItem Value="Germany">Germany</asp:ListItem>
                  <asp:ListItem Value="Ghana">Ghana</asp:ListItem>
                  <asp:ListItem Value="Gibraltar">Gibraltar</asp:ListItem>
                  <asp:ListItem Value="Great Britain">Great Britain</asp:ListItem>
                  <asp:ListItem Value="Greece">Greece</asp:ListItem>
                  <asp:ListItem Value="Greenland">Greenland</asp:ListItem>
                  <asp:ListItem Value="Grenada">Grenada</asp:ListItem>
                  <asp:ListItem Value="Guadeloupe">Guadeloupe</asp:ListItem>
                  <asp:ListItem Value="Guam">Guam</asp:ListItem>
                  <asp:ListItem Value="Guatemala">Guatemala</asp:ListItem>
                  <asp:ListItem Value="Guinea">Guinea</asp:ListItem>
                  <asp:ListItem Value="Guyana">Guyana</asp:ListItem>
                  <asp:ListItem Value="Haiti">Haiti</asp:ListItem>
                  <asp:ListItem Value="Hawaii">Hawaii</asp:ListItem>
                  <asp:ListItem Value="Honduras">Honduras</asp:ListItem>
                  <asp:ListItem Value="Hong Kong">Hong Kong</asp:ListItem>
                  <asp:ListItem Value="Hungary">Hungary</asp:ListItem>
                  <asp:ListItem Value="Iceland">Iceland</asp:ListItem>
                  <asp:ListItem Value="India">India</asp:ListItem>
                  <asp:ListItem Value="Indonesia">Indonesia</asp:ListItem>
                  <asp:ListItem Value="Iran">Iran</asp:ListItem>
                  <asp:ListItem Value="Iraq">Iraq</asp:ListItem>
                  <asp:ListItem Value="Ireland">Ireland</asp:ListItem>
                  <asp:ListItem Value="Isle of Man">Isle of Man</asp:ListItem>
                  <asp:ListItem Value="Israel">Israel</asp:ListItem>
                  <asp:ListItem Value="Italy">Italy</asp:ListItem>
                  <asp:ListItem Value="Jamaica">Jamaica</asp:ListItem>
                  <asp:ListItem Value="Japan">Japan</asp:ListItem>
                  <asp:ListItem Value="Jordan">Jordan</asp:ListItem>
                  <asp:ListItem Value="Kazakhstan">Kazakhstan</asp:ListItem>
                  <asp:ListItem Value="Kenya">Kenya</asp:ListItem>
                  <asp:ListItem Value="Kiribati">Kiribati</asp:ListItem>
                  <asp:ListItem Value="Korea North">Korea North</asp:ListItem>
                  <asp:ListItem Value="Korea Sout">Korea South</asp:ListItem>
                  <asp:ListItem Value="Kuwait">Kuwait</asp:ListItem>
                  <asp:ListItem Value="Kyrgyzstan">Kyrgyzstan</asp:ListItem>
                  <asp:ListItem Value="Laos">Laos</asp:ListItem>
                  <asp:ListItem Value="Latvia">Latvia</asp:ListItem>
                  <asp:ListItem Value="Lebanon">Lebanon</asp:ListItem>
                  <asp:ListItem Value="Lesotho">Lesotho</asp:ListItem>
                  <asp:ListItem Value="Liberia">Liberia</asp:ListItem>
                  <asp:ListItem Value="Libya">Libya</asp:ListItem>
                  <asp:ListItem Value="Liechtenstein">Liechtenstein</asp:ListItem>
                  <asp:ListItem Value="Lithuania">Lithuania</asp:ListItem>
                  <asp:ListItem Value="Luxembourg">Luxembourg</asp:ListItem>
                  <asp:ListItem Value="Macau">Macau</asp:ListItem>
                  <asp:ListItem Value="Macedonia">Macedonia</asp:ListItem>
                  <asp:ListItem Value="Madagascar">Madagascar</asp:ListItem>
                  <asp:ListItem Value="Malaysia">Malaysia</asp:ListItem>
                  <asp:ListItem Value="Malawi">Malawi</asp:ListItem>
                  <asp:ListItem Value="Maldives">Maldives</asp:ListItem>
                  <asp:ListItem Value="Mali">Mali</asp:ListItem>
                  <asp:ListItem Value="Malta">Malta</asp:ListItem>
                  <asp:ListItem Value="Marshall Islands">Marshall Islands</asp:ListItem>
                  <asp:ListItem Value="Martinique">Martinique</asp:ListItem>
                  <asp:ListItem Value="Mauritania">Mauritania</asp:ListItem>
                  <asp:ListItem Value="Mauritius">Mauritius</asp:ListItem>
                  <asp:ListItem Value="Mayotte">Mayotte</asp:ListItem>
                  <asp:ListItem Value="Mexico">Mexico</asp:ListItem>
                  <asp:ListItem Value="Midway Islands">Midway Islands</asp:ListItem>
                  <asp:ListItem Value="Moldova">Moldova</asp:ListItem>
                  <asp:ListItem Value="Monaco">Monaco</asp:ListItem>
                  <asp:ListItem Value="Mongolia">Mongolia</asp:ListItem>
                  <asp:ListItem Value="Montserrat">Montserrat</asp:ListItem>
                  <asp:ListItem Value="Morocco">Morocco</asp:ListItem>
                  <asp:ListItem Value="Mozambique">Mozambique</asp:ListItem>
                  <asp:ListItem Value="Myanmar">Myanmar</asp:ListItem>
                  <asp:ListItem Value="Nambia">Nambia</asp:ListItem>
                  <asp:ListItem Value="Nauru">Nauru</asp:ListItem>
                  <asp:ListItem Value="Nepal">Nepal</asp:ListItem>
                  <asp:ListItem Value="Netherland Antilles">Netherland Antilles</asp:ListItem>
                  <asp:ListItem Value="Netherlands">Netherlands (Holland, Europe)</asp:ListItem>
                  <asp:ListItem Value="Nevis">Nevis</asp:ListItem>
                  <asp:ListItem Value="New Caledonia">New Caledonia</asp:ListItem>
                  <asp:ListItem Value="New Zealand">New Zealand</asp:ListItem>
                  <asp:ListItem Value="Nicaragua">Nicaragua</asp:ListItem>
                  <asp:ListItem Value="Niger">Niger</asp:ListItem>
                  <asp:ListItem Value="Nigeria">Nigeria</asp:ListItem>
                  <asp:ListItem Value="Niue">Niue</asp:ListItem>
                  <asp:ListItem Value="Norfolk Island">Norfolk Island</asp:ListItem>
                  <asp:ListItem Value="Norway">Norway</asp:ListItem>
                  <asp:ListItem Value="Oman">Oman</asp:ListItem>
                  <asp:ListItem Value="Pakistan">Pakistan</asp:ListItem>
                  <asp:ListItem Value="Palau Island">Palau Island</asp:ListItem>
                  <asp:ListItem Value="Palestine">Palestine</asp:ListItem>
                  <asp:ListItem Value="Panama">Panama</asp:ListItem>
                  <asp:ListItem Value="Papua New Guinea">Papua New Guinea</asp:ListItem>
                  <asp:ListItem Value="Paraguay">Paraguay</asp:ListItem>
                  <asp:ListItem Value="Peru">Peru</asp:ListItem>
                  <asp:ListItem Value="Phillipines">Philippines</asp:ListItem>
                  <asp:ListItem Value="Pitcairn Island">Pitcairn Island</asp:ListItem>
                  <asp:ListItem Value="Poland">Poland</asp:ListItem>
                  <asp:ListItem Value="Portugal">Portugal</asp:ListItem>
                  <asp:ListItem Value="Puerto Rico">Puerto Rico</asp:ListItem>
                  <asp:ListItem Value="Qatar">Qatar</asp:ListItem>
                  <asp:ListItem Value="Republic of Montenegro">Republic of Montenegro</asp:ListItem>
                  <asp:ListItem Value="Republic of Serbia">Republic of Serbia</asp:ListItem>
                  <asp:ListItem Value="Reunion">Reunion</asp:ListItem>
                  <asp:ListItem Value="Romania">Romania</asp:ListItem>
                  <asp:ListItem Value="Russia">Russia</asp:ListItem>
                  <asp:ListItem Value="Rwanda">Rwanda</asp:ListItem>
                  <asp:ListItem Value="St Barthelemy">St Barthelemy</asp:ListItem>
                  <asp:ListItem Value="St Eustatius">St Eustatius</asp:ListItem>
                  <asp:ListItem Value="St Helena">St Helena</asp:ListItem>
                  <asp:ListItem Value="St Kitts-Nevis">St Kitts-Nevis</asp:ListItem>
                  <asp:ListItem Value="St Lucia">St Lucia</asp:ListItem>
                  <asp:ListItem Value="St Maarten">St Maarten</asp:ListItem>
                  <asp:ListItem Value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</asp:ListItem>
                  <asp:ListItem Value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</asp:ListItem>
                  <asp:ListItem Value="Saipan">Saipan</asp:ListItem>
                  <asp:ListItem Value="Samoa">Samoa</asp:ListItem>
                  <asp:ListItem Value="Samoa American">Samoa American</asp:ListItem>
                  <asp:ListItem Value="San Marino">San Marino</asp:ListItem>
                  <asp:ListItem Value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</asp:ListItem>
                  <asp:ListItem Value="Saudi Arabia">Saudi Arabia</asp:ListItem>
                  <asp:ListItem Value="Senegal">Senegal</asp:ListItem>
                  <asp:ListItem Value="Seychelles">Seychelles</asp:ListItem>
                  <asp:ListItem Value="Sierra Leone">Sierra Leone</asp:ListItem>
                  <asp:ListItem Value="Singapore">Singapore</asp:ListItem>
                  <asp:ListItem Value="Slovakia">Slovakia</asp:ListItem>
                  <asp:ListItem Value="Slovenia">Slovenia</asp:ListItem>
                  <asp:ListItem Value="Solomon Islands">Solomon Islands</asp:ListItem>
                  <asp:ListItem Value="Somalia">Somalia</asp:ListItem>
                  <asp:ListItem Value="South Africa">South Africa</asp:ListItem>
                  <asp:ListItem Value="Spain">Spain</asp:ListItem>
                  <asp:ListItem Value="Sri Lanka">Sri Lanka</asp:ListItem>
                  <asp:ListItem Value="Sudan">Sudan</asp:ListItem>
                  <asp:ListItem Value="Suriname">Suriname</asp:ListItem>
                  <asp:ListItem Value="Swaziland">Swaziland</asp:ListItem>
                  <asp:ListItem Value="Sweden">Sweden</asp:ListItem>
                  <asp:ListItem Value="Switzerland">Switzerland</asp:ListItem>
                  <asp:ListItem Value="Syria">Syria</asp:ListItem>
                  <asp:ListItem Value="Tahiti">Tahiti</asp:ListItem>
                  <asp:ListItem Value="Taiwan">Taiwan</asp:ListItem>
                  <asp:ListItem Value="Tajikistan">Tajikistan</asp:ListItem>
                  <asp:ListItem Value="Tanzania">Tanzania</asp:ListItem>
                  <asp:ListItem Value="Thailand">Thailand</asp:ListItem>
                  <asp:ListItem Value="Togo">Togo</asp:ListItem>
                  <asp:ListItem Value="Tokelau">Tokelau</asp:ListItem>
                  <asp:ListItem Value="Tonga">Tonga</asp:ListItem>
                  <asp:ListItem Value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</asp:ListItem>
                  <asp:ListItem Value="Tunisia">Tunisia</asp:ListItem>
                  <asp:ListItem Value="Turkey">Turkey</asp:ListItem>
                  <asp:ListItem Value="Turkmenistan">Turkmenistan</asp:ListItem>
                  <asp:ListItem Value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</asp:ListItem>
                  <asp:ListItem Value="Tuvalu">Tuvalu</asp:ListItem>
                  <asp:ListItem Value="Uganda">Uganda</asp:ListItem>
                  <asp:ListItem Value="Ukraine">Ukraine</asp:ListItem>
                  <asp:ListItem Value="United Arab Erimates">United Arab Emirates</asp:ListItem>
                  <asp:ListItem Value="United Kingdom">United Kingdom</asp:ListItem>
                  <asp:ListItem Value="United States of America">United States of America</asp:ListItem>
                  <asp:ListItem Value="Uraguay">Uruguay</asp:ListItem>
                  <asp:ListItem Value="Uzbekistan">Uzbekistan</asp:ListItem>
                  <asp:ListItem Value="Vanuatu">Vanuatu</asp:ListItem>
                  <asp:ListItem Value="Vatican City State">Vatican City State</asp:ListItem>
                  <asp:ListItem Value="Venezuela">Venezuela</asp:ListItem>
                  <asp:ListItem Value="Vietnam">Vietnam</asp:ListItem>
                  <asp:ListItem Value="Virgin Islands (Brit)">Virgin Islands (Brit)</asp:ListItem>
                  <asp:ListItem Value="Virgin Islands (USA)">Virgin Islands (USA)</asp:ListItem>
                  <asp:ListItem Value="Wake Island">Wake Island</asp:ListItem>
                  <asp:ListItem Value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</asp:ListItem>
                  <asp:ListItem Value="Yemen">Yemen</asp:ListItem>
                  <asp:ListItem Value="Zaire">Zaire</asp:ListItem>
                  <asp:ListItem Value="Zambia">Zambia</asp:ListItem>
                  <asp:ListItem Value="Zimbabwe">Zimbabwe</asp:ListItem>
               </asp:DropDownList>                                          
            </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Email*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Email" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
      </asp:Table>
      <asp:Button ID="YesButton" runat="server" Text="Yes I agree, begin download" onclick="YesButton_Click" Width="238px" />
      <asp:Button ID="NoButton" runat="server" Text="No I don't agree, go back" 
            onclick="NoButton_Click" /><br />
      <asp:Label ID="CompleteLabel" runat="server" Text="            " Font-Bold="True" 
         ForeColor="#0066FF"></asp:Label>
      </form>
      <asp:Label runat="server">Terms:</asp:Label>
      <asp:Table 
         ID="Table2" runat="server" Height="100px" Width="836px"
         EnableTheming="True">
         <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="Terms" runat="server"></asp:TableCell>
         </asp:TableRow>
      </asp:Table>      
</body>
</html>

