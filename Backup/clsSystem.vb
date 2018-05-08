'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subUserSelect
'*** B. subUserAction
'*** C. subModuleSelect
'*** D. subMoudleAction
'*** E. subPersonSelect
'*** F. subPersonAction
'*** G. fncSecurityCheck
'****************************************
'****************************************

Public Class clsSystem
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subUserSelect
    Public Sub subUserSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intUserID As Integer, _
    ByVal intPersonID As Integer, ByVal strUserName As String, ByVal strPassword As String, _
    ByVal dtPasswordDate As Date, ByVal strStatus As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procUser"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserID", intUserID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strUserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Password", strPassword)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PasswordDate", dtPasswordDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUser")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmLogin"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsUser")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsUser"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmLogin.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmLogin.txtUserName.DataBindings.Clear()
                frmLogin.txtPasswordTemp.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmLogin.txtUserName.DataBindings.Add("text", objDataView, "UserName")
                frmLogin.txtPasswordTemp.DataBindings.Add("text", objDataView, "Password")
                frmLogin.txtPasswordTemp.Visible = False
                frmLogin.txtPasswordDateTemp.DataBindings.Add("text", objDataView, "PasswordDate")
                frmLogin.txtPasswordDateTemp.Visible = False
                frmLogin.txtStatus.DataBindings.Add("text", objDataView, "Status")
                frmLogin.txtStatus.Visible = False
                frmLogin.txtUserID.DataBindings.Add("text", objDataView, "UserID")
                frmLogin.txtUserID.Visible = False

            Case "frmUser"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsUSER")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsUser"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUser.txtUserID.DataBindings.Clear()
                frmUser.txtUserName.DataBindings.Clear()
                frmUser.txtPassword.DataBindings.Clear()
                frmUser.txtPasswordDate.DataBindings.Clear()
                frmUser.cboStatus.DataBindings.Clear()
                frmUser.txtCreateUser.DataBindings.Clear()
                frmUser.txtCreateDate.DataBindings.Clear()


                'Add new bindings to the DataView object...
                frmUser.txtUserID.Visible = True
                frmUser.txtUserID.DataBindings.Add("text", objDataView, "UserID")
                frmUser.txtUserID.Visible = False
                frmUser.txtUserName.DataBindings.Add("text", objDataView, "UserName")
                frmUser.txtPassword.DataBindings.Add("text", objDataView, "Password")
                frmUser.txtPasswordDate.DataBindings.Add("text", objDataView, "PasswordDate")
                frmUser.cboStatus.DataBindings.Add("text", objDataView, "Status")
                frmUser.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmUser.txtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")

            Case "frmUserPassword"

                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsUSER")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsUser"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUserPassword.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUserPassword.txtUserID.DataBindings.Clear()
                frmUserPassword.txtUserName.DataBindings.Clear()
                frmUserPassword.txtOldPassword.DataBindings.Clear()


                'Add new bindings to the DataView object...
                frmUserPassword.txtUserID.Visible = True
                frmUserPassword.txtUserID.DataBindings.Add("text", objDataView, "UserID")
                frmUserPassword.txtUserID.Visible = False
                frmUserPassword.txtUserName.DataBindings.Add("text", objDataView, "UserName")
                frmUserPassword.txtOldPasswordTemp.DataBindings.Add("text", objDataView, "Password")
                frmUserPassword.txtOldPasswordTemp.Visible = False
                
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsUser"

                'Setup form title...
                frmSearch.Text = "User Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Visible = False
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Width = 100
                frmSearch.grdDataList.Columns(5).Width = 180
                frmSearch.grdDataList.Columns(6).Width = 50

                'Setup column headers...
                frmSearch.grdDataList.Columns(2).HeaderText = "Last Name"
                frmSearch.grdDataList.Columns(3).HeaderText = "First Name"
                frmSearch.grdDataList.Columns(4).HeaderText = "User Name"
                frmSearch.grdDataList.Columns(5).HeaderText = "E-mail Address"
                frmSearch.grdDataList.Columns(6).HeaderText = "Status"

            Case "Get-UserID"

                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsUser")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsUser"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmMainMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmMainMenu.txtDFunctionID.DataBindings.Clear()
                frmMainMenu.txtDFunctionID.Text = ""

                'Add new bindings to the DataView object...
                frmMainMenu.txtDFunctionID.Visible = True
                frmMainMenu.txtDFunctionID.DataBindings.Add("text", objDataView, "UserID")
                frmMainMenu.txtDFunctionID.Visible = False
            Case "frmCashierActivity-cb"
                'frmCashierActivity.cboCashier.DataBindings.Clear()
                frmCashierActivity.cboCashier.DataSource = objDataSet.Tables("dsUser")
                frmCashierActivity.cboCashier.DisplayMember = "UserName"
                frmCashierActivity.cboCashier.ValueMember = "UserName"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objUserData = New clsSystem
        'Call objUserData.subUserSelect(strBindTarget:="frmLogin", strAction:="SELECT-USERNAME", _
        'intUserID:=0, intPersonID:=0,strUserName:=SystemInformation.UserName,strPassword:="NONE",dtPasswordDate:="01/01/1900", _
        'strStatus:="A",strCreateUser:="NONE",dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subUserAction
    Public Sub subUserAction(ByVal strAction As String, ByVal intUserID As Integer, _
        ByVal intPersonID As Integer, ByVal strUserName As String, ByVal strPassword As String, _
        ByVal dtPasswordDate As Date, ByVal strStatus As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procUser"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@UserID", intUserID)
        objCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objCommand.Parameters.AddWithValue("@UserName", strUserName)
        objCommand.Parameters.AddWithValue("@Password", strPassword)
        objCommand.Parameters.AddWithValue("@PasswordDate", dtPasswordDate)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        frmCashierActivity.intRetCashierRecNbr = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objUserAction = New clsSystem
        'Call objUserAction.subUserAction(strAction:="UPDATE", intUserID:=Me.txtUserID.Text, intPersonID:=Me.txtPersonID.Text, _
        '    strUserName:=Me.txtUserName.Text, strPassword:=Me.txtPassword.Text, dtPasswordDate:=Me.txtPasswordDate.Text, _
        '    strStatus:=Me.cboStatus.Text, strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** C. subModuleSelect
    Public Sub subModuleSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intUserID As Integer, ByVal strUserName As String, _
            ByVal intModuleID As Integer, ByVal strModuleCategory As String, ByVal intLinkID As Integer)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procModule"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserID", intUserID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strUserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ModuleID", intModuleID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ModuleCategory", strModuleCategory)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LinkID", intLinkID)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsModule")

        'Close the database connection...
        objConnection.Close()

        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmModuleMenu"
                'Inialize a new instance of the DataSet
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmModuleMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmModuleMenu.lstModules.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmModuleMenu.lstModules.DataSource = objDataSet.Tables("dsModule")
                frmModuleMenu.lstModules.DisplayMember = "ModuleType"
            Case "frmUser.lstModules"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUser.lstModules.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.lstModules.DataSource = objDataSet.Tables("dsModule")
                frmUser.lstModules.DisplayMember = "ModuleType"
                frmUser.lstModules.ValueMember = "ModuleTypeID"
            Case "frmUser.lstOrganizations"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUser.lstOrganizations.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.lstOrganizations.DataSource = objDataSet.Tables("dsModule")
                frmUser.lstOrganizations.DisplayMember = "UserOrganizationSuffix"
                frmUser.lstOrganizations.ValueMember = "UserOrganizationID"
            Case "frmUser.lstModulesSelected"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)
                'Clear any previous bindings...
                frmUser.lstModulesSelected.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.lstModulesSelected.DataSource = objDataSet.Tables("dsModule")
                frmUser.lstModulesSelected.DisplayMember = "ModuleType"
                frmUser.lstModulesSelected.ValueMember = "LinkID"

                frmUser.cboModules.DataSource = objDataSet.Tables("dsModule")
                frmUser.cboModules.DisplayMember = "ModuleType"
                frmUser.cboModules.ValueMember = "ModuleTypeID"
            Case "frmUser.lstOrganizationsSelected"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)
                'Clear any previous bindings...
                frmUser.lstModulesSelected.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.lstOrganizationsSelected.DataSource = objDataSet.Tables("dsModule")
                frmUser.lstOrganizationsSelected.DisplayMember = "UserOrganizationSuffix"
                frmUser.lstOrganizationsSelected.ValueMember = "LinkID"

            Case "frmUser.lstRoles"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUser.lstRoles.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.lstRoles.DataSource = objDataSet.Tables("dsModule")
                frmUser.lstRoles.DisplayMember = "ModuleRole"
                frmUser.lstRoles.ValueMember = "ModuleRoleID"

            Case "frmUser.lstRolesSelected"
                ''Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                ''Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "RoleSelect")

                ''Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("RoleSelect"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUser.lstRolesSelected.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.lstRolesSelected.DataSource = objDataSet.Tables("RoleSelect")
                frmUser.lstRolesSelected.DisplayMember = "ModuleRole"
                frmUser.lstRolesSelected.ValueMember = "LinkID"

            Case "MODULE-INSTANCE-COUNT"

                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmMainMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmMainMenu.txtDFunctionID.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmMainMenu.txtDFunctionID.Visible = True
                frmMainMenu.txtDFunctionID.DataBindings.Add("text", objDataView, "InstanceCount")
                frmMainMenu.txtDFunctionID.Visible = False

            Case "ROLE-INSTANCE-COUNT"

                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmMainMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmMainMenu.txtDFunctionID.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmMainMenu.txtDFunctionID.Visible = True
                frmMainMenu.txtDFunctionID.DataBindings.Add("text", objDataView, "InstanceCount")
                frmMainMenu.txtDFunctionID.Visible = False
            Case "ORG-INSTANCE-COUNT"

                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsModule")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsModule"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmMainMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmMainMenu.txtDFunctionID.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmMainMenu.txtDFunctionID.Visible = True
                frmMainMenu.txtDFunctionID.DataBindings.Add("text", objDataView, "InstanceCount")
                frmMainMenu.txtDFunctionID.Visible = False

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objModuleData = New clsSystem
        'Call objModuleData.subModuleSelect(strBindTarget:="frmModuleMenu", strAction:="SELECT-MODULETYPE-ACCESS", _
        'intUserID:=0, strUserName:=SystemInformation.UserName, intModuleID:=0, strModuleCategory:="NONE", intLinkID:=0)
        '***********************************************
        '***********************************************
    End Sub

    '*** D. subModuleAction
    Public Sub subModuleAction(ByVal strAction As String, ByVal intUserID As Integer, ByVal strUserName As String, _
        ByVal intModuleID As Integer, ByVal strModuleCategory As String, ByVal intLinkID As Integer)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procModule"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@UserID", intUserID)
        objCommand.Parameters.AddWithValue("@UserName", strUserName)
        objCommand.Parameters.AddWithValue("@ModuleID", intModuleID)
        objCommand.Parameters.AddWithValue("@ModuleCategory", strModuleCategory)
        objCommand.Parameters.AddWithValue("@LinkID", intLinkID)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objModuleAction = New clsSystem
        'Call objModuleAction.subModuleAction(strAction:="ADD-MODULE-ACCESS", intUserID:=Me.txtUserID.Text, _
        '    strUserName:="NONE", intModuleID:=lstModules.SelectedValue, strModuleCategory:="MODULE", intLinkID:=0)
        '***********************************************
        '***********************************************

    End Sub

    '*** E. subPersonSelect
    Public Sub subPersonSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intPersonID As Integer, _
    ByVal strLName As String, ByVal strFName As String, ByVal strMI As String, ByVal strSalutation As String, _
    ByVal strPrefPhone As String, ByVal strPrefFax As String, ByVal strCell As String, ByVal strEmail As String, _
    ByVal strBoxNumber As String, ByVal strStatus As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procPerson"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LName", strLName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FName", strFName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MI", strMI)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Salutation", strSalutation)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PrefPhone", strPrefPhone)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PrefFax", strPrefFax)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Cell", strCell)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Email", strEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BoxNumber", strBoxNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsPerson")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmPerson"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsPerson")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsPerson"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmPerson.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmPerson.txtFName.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmPerson.txtPersonID.Visible = True
                frmPerson.txtPersonID.DataBindings.Add("text", objDataView, "PersonID")
                frmPerson.txtPersonID.Visible = False
                frmPerson.txtLName.DataBindings.Add("text", objDataView, "LName")
                frmPerson.txtFName.DataBindings.Add("text", objDataView, "FName")
                frmPerson.txtMI.DataBindings.Add("text", objDataView, "MI")
                frmPerson.txtSalutation.DataBindings.Add("text", objDataView, "Salutation")
                frmPerson.txtPrefPhone.DataBindings.Add("text", objDataView, "PrefPhone")
                frmPerson.txtPrefFax.DataBindings.Add("text", objDataView, "PrefFax")
                frmPerson.txtCell.DataBindings.Add("text", objDataView, "Cell")
                frmPerson.txtEmail.DataBindings.Add("text", objDataView, "Email")
                frmPerson.cboStatus.DataBindings.Add("text", objDataView, "Status")
                frmPerson.txtBoxNumber.DataBindings.Add("text", objDataView, "BoxNumber")
                frmPerson.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmPerson.txtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")
                If frmPerson.txtPersonID.Text = 59 Then
                    'Person Record = "Not Listed"
                    'Lock down the form
                    frmPerson.txtLName.Enabled = False
                    frmPerson.txtFName.Enabled = False
                    frmPerson.txtMI.Enabled = False
                    frmPerson.txtSalutation.Enabled = False
                    frmPerson.txtPrefPhone.Enabled = False
                    frmPerson.txtPrefFax.Enabled = False
                    frmPerson.txtCell.Enabled = False
                    frmPerson.txtEmail.Enabled = False
                    frmPerson.cboStatus.Enabled = False
                    frmPerson.txtBoxNumber.Enabled = False
                    frmPerson.txtCreateUser.Enabled = False
                    frmPerson.txtCreateDate.Enabled = False
                End If


            Case "frmUser"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsPerson")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsPerson"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmUser.txtPersonID.DataBindings.Clear()
                frmUser.txtLName.DataBindings.Clear()
                frmUser.txtFName.DataBindings.Clear()
                frmUser.txtMI.DataBindings.Clear()
                frmUser.txtPrefPhone.DataBindings.Clear()
                frmUser.txtPrefFax.DataBindings.Clear()
                frmUser.txtCell.DataBindings.Clear()
                frmUser.txtEmail.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmUser.txtPersonID.Visible = True
                frmUser.txtPersonID.DataBindings.Add("text", objDataView, "PersonID")
                frmUser.txtPersonID.Visible = False
                frmUser.txtLName.DataBindings.Add("text", objDataView, "LName")
                frmUser.txtFName.DataBindings.Add("text", objDataView, "FName")
                frmUser.txtMI.DataBindings.Add("text", objDataView, "MI")
                frmUser.txtPrefPhone.DataBindings.Add("text", objDataView, "PrefPhone")
                frmUser.txtPrefFax.DataBindings.Add("text", objDataView, "PrefFax")
                frmUser.txtCell.DataBindings.Add("text", objDataView, "Cell")
                frmUser.txtEmail.DataBindings.Add("text", objDataView, "Email")

            Case "frmStaff"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsStaff")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsStaff"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmStaff.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmStaff.txtPersonID.DataBindings.Clear()
                frmStaff.txtLName.DataBindings.Clear()
                frmStaff.txtFName.DataBindings.Clear()
                frmStaff.txtMI.DataBindings.Clear()
                frmStaff.txtPrefPhone.DataBindings.Clear()
                frmStaff.txtPrefFax.DataBindings.Clear()
                frmStaff.txtCell.DataBindings.Clear()
                frmStaff.txtEmail.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmStaff.txtPersonID.Visible = True
                frmStaff.txtPersonID.DataBindings.Add("text", objDataView, "PersonID")
                frmStaff.txtPersonID.Visible = False
                frmStaff.txtLName.DataBindings.Add("text", objDataView, "LName")
                frmStaff.txtFName.DataBindings.Add("text", objDataView, "FName")
                frmStaff.txtMI.DataBindings.Add("text", objDataView, "MI")
                frmStaff.txtPrefPhone.DataBindings.Add("text", objDataView, "PrefPhone")
                frmStaff.txtPrefFax.DataBindings.Add("text", objDataView, "PrefFax")
                frmStaff.txtCell.DataBindings.Add("text", objDataView, "Cell")
                frmStaff.txtEmail.DataBindings.Add("text", objDataView, "Email")

            Case "frmMerchant"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsPerson")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsPerson"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmUser.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmMerchant.txtPersonID.DataBindings.Clear()
                frmMerchant.txtLName.DataBindings.Clear()
                frmMerchant.txtFName.DataBindings.Clear()
                frmMerchant.txtMI.DataBindings.Clear()
                frmMerchant.txtPrefPhone.DataBindings.Clear()
                frmMerchant.txtPrefFax.DataBindings.Clear()
                frmMerchant.txtCell.DataBindings.Clear()
                frmMerchant.txtEmail.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmMerchant.txtPersonID.Visible = True
                frmMerchant.txtPersonID.DataBindings.Add("text", objDataView, "PersonID")
                frmMerchant.txtPersonID.Visible = False
                frmMerchant.txtLName.DataBindings.Add("text", objDataView, "LName")
                frmMerchant.txtFName.DataBindings.Add("text", objDataView, "FName")
                frmMerchant.txtMI.DataBindings.Add("text", objDataView, "MI")
                frmMerchant.txtPrefPhone.DataBindings.Add("text", objDataView, "PrefPhone")
                frmMerchant.txtPrefFax.DataBindings.Add("text", objDataView, "PrefFax")
                frmMerchant.txtCell.DataBindings.Add("text", objDataView, "Cell")
                frmMerchant.txtEmail.DataBindings.Add("text", objDataView, "Email")
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsPerson"

                'Setup form title...
                frmSearch.Text = "Person Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Visible = 100
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Width = 190
                frmSearch.grdDataList.Columns(5).Width = 50


                'Setup column headers...
                frmSearch.grdDataList.Columns(1).HeaderText = "Last Name"
                frmSearch.grdDataList.Columns(2).HeaderText = "First Name"
                frmSearch.grdDataList.Columns(3).HeaderText = "Phone"
                frmSearch.grdDataList.Columns(4).HeaderText = "E-mail Address"
                frmSearch.grdDataList.Columns(5).HeaderText = "Status"

            Case "Max-PersonID"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsPerson")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsPerson"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmMainMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmMainMenu.txtDFunctionID.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmMainMenu.txtDFunctionID.Visible = True
                frmMainMenu.txtDFunctionID.DataBindings.Add("text", objDataView, "MaxPersonID")
                frmMainMenu.txtDFunctionID.Visible = False
            Case "frmMerchants-Contact-cbo"
                frmMerchants.cboPerson.DataSource = objDataSet.Tables(0)
                frmMerchants.cboPerson.DisplayMember = "Name"
                frmMerchants.cboPerson.ValueMember = "PersonID"
            Case "frmMerchants-Contact-fields"
                'frmMerchants.cboPerson.DataSource = objDataSet.Tables(0)
                frmMerchants.txtPhone.Text = objDataSet.Tables(0).Rows(0).Item("PrefPhone").ToString
                frmMerchants.txtEmail.Text = objDataSet.Tables(0).Rows(0).Item("Email").ToString
            Case "frmMerchants-Contact-cbo-Text"
                frmMerchants.cboPerson.Text = objDataSet.Tables(0).Rows(0).Item("Name")
                frmMerchants.intContactID = objDataSet.Tables(0).Rows(0).Item("PersonID")
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objPersonData = New clsSystem
        'Call objPersonData.subPersonSelect(strBindTarget:="frmPerson", strAction:="SELECT", intPersonID:=frmMainMenu.txtActionID.Text, _
        'strLName:="NONE", strFName:="NONE",strMI:="X",strSalutation:="NONE",strPrefPhone:="0000000000",strPrefFax:="0000000000", _
        ' strCell:="0000000000",strEmail:="NONE",strBoxNumber:="NONE",strStatus:="A",strCreateUser:="NONE",dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** F. subPersonAction
    Public Sub subPersonAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal intPersonID As Integer, _
    ByVal strLName As String, ByVal strFName As String, ByVal strMI As String, ByVal strSalutation As String, _
    ByVal strPrefPhone As String, ByVal strPrefFax As String, ByVal strCell As String, ByVal strEmail As String, _
    ByVal strBoxNumber As String, ByVal strStatus As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)


        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procPerson"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objCommand.Parameters.AddWithValue("@LName", strLName)
        objCommand.Parameters.AddWithValue("@FName", strFName)
        objCommand.Parameters.AddWithValue("@MI", strMI)
        objCommand.Parameters.AddWithValue("@Salutation", strSalutation)
        objCommand.Parameters.AddWithValue("@PrefPhone", strPrefPhone)
        objCommand.Parameters.AddWithValue("@PrefFax", strPrefFax)
        objCommand.Parameters.AddWithValue("@Cell", strCell)
        objCommand.Parameters.AddWithValue("@Email", strEmail)
        objCommand.Parameters.AddWithValue("@BoxNumber", strBoxNumber)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objPersonAction = New clsSystem
        'Call objPersonAction.subPersonAction(strBindTarget:="frmPerson", strAction:="DELETE", intPersonID:=Me.txtPersonID.Text, _
        'strLName:="NONE", strFName:="NONE",strMI:="X",strSalutation:="NONE",strPrefPhone:="0000000000",strPrefFax:="0000000000", _
        ' strCell:="0000000000",strEmail:="NONE",strBoxNumber:="NONE",strStatus:="A",strCreateUser:="NONE",dtCreateDate:=Format(System.DateTime.Now, "short date"))
        '***********************************************
        '***********************************************
    End Sub

    '*** G. fncSecurityCheck
    Public Function fncSecurityCheck(ByVal strAction As String, ByVal strRole As String) As String
        Dim strPassFail As String
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procModule"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ModuleID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ModuleCategory", strRole)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LinkID", 0)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsSecurityCheck")

        'Close the database connection...
        objConnection.Close()

        'Check for access..
        If objDataSet.Tables("dsSecurityCheck").Rows.Count = 0 Then
            'No match, access denied...
            strPassFail = "FAIL"
        Else
            'Match found, allow access..
            strPassFail = "PASS"
        End If

        'Next
        Cursor.Current = Cursors.Arrow
        Return strPassFail

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objSecurityCheck = New clsSystem

        'strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="ELM-ROLE-CHECK", strRole:="Search - Reports")
        'If strPassFail = "PASS" Then
        'Set the parent of module menu screen and open it...
        '       **ADD OPEN ACCESS ACTION HERE
        'Else
        '      MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        'End If
        '***********************************************
        '***********************************************

    End Function


End Class
