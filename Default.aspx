<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="BLaST_3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Student Fact Template – Special Education for the Act 16 Report</title>
        <link rel="stylesheet"
            href="StyleSheet1.css" />
    </head>
    
<body>
    <header>
        <h1>
            Student Fact Template – Special Education for the Act 16 Report 
         </h1>
    </header>
    <br />
    <br />
    <form id="form1" runat="server">
        <div>
            <label for="txtAUN" class="title">Submitting AUN: </label>
            <asp:TextBox ID="txtAUN" TextMode="Number" MaxLength="9" runat="server"></asp:TextBox>
            <br />
            <br />
            <label for="dateSchoolYear" class="title">School Year Date:   </label>
            <asp:TextBox ID="dateSchoolYear" TextMode="Date"  MaxLength="10" runat="server" Text='<%# Bind("SchoolYearDate", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
            <br />
            <br />
            <label for="txtID" class="title">PA Secure ID:    </label>
            <asp:TextBox ID="txtID" TextMode="Number" MaxLength="10" runat="server"></asp:TextBox>
            <br />
            <br />
            <label for="dateReporting" class="title">Reporting Date:  </label>
            <asp:TextBox ID="dateReporting" TextMode="Date"  MaxLength="10" runat="server" Text='<%# Bind("ReportingDate", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
            <br />
            <br />
            <label for="Act16" class="title">Collection:  </label>
            <asp:TextBox ID="Act16" runat="server" Enabled="False" Text="Act16"></asp:TextBox>
            <br />
            <br />
            <label for="MeasureType" class="title">Measure Type:  </label>
            <asp:TextBox ID="MeasureType" runat="server" Enabled="False" Text="Count"></asp:TextBox>
            <br />
            <br />

            <label for="fundCategory" class="title">Fund Category:    </label>
            <asp:DropDownList ID="fundCategory" runat="server">
                
                <asp:ListItem
                Text=""
                Value=""
                    />

                <asp:ListItem
                Text="Category 1"
                Value="1"
                    />

                <asp:ListItem
                Text="Category 2"
                Value="2"
                    />

                <asp:ListItem
                Text="Category 3A"
                Value="3"
                    />

                <asp:ListItem
                Text="Category 3B"
                Value="4"
                    />

            </asp:DropDownList>
            <br />
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            
            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
            <br />
            <br />
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </div>
        
    </form>
</body>
</html>
