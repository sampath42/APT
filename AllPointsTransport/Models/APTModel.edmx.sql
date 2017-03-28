
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/25/2017 16:02:54
-- Generated from EDMX file: C:\Users\jsfre\Desktop\Visual Studio Projects\AllPointsTransport\AllPointsTransport\Models\APTModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AllPointsTransport];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[Drivers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drivers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[RowColors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RowColors];
GO
IF OBJECT_ID(N'[dbo].[RowColorsDriver]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RowColorsDriver];
GO
IF OBJECT_ID(N'[dbo].[Schedules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schedules];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TaskManagement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskManagement];
GO
IF OBJECT_ID(N'[dbo].[Trucks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trucks];
GO
IF OBJECT_ID(N'[dbo].[WorkOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkOrders];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[DriverPay]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[DriverPay];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[Payroll]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[Payroll];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[Settings]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[Settings];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[TemplatesDriverPay]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[TemplatesDriverPay];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[TemplatesWO]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[TemplatesWO];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[TemplatesWOLineItems]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[TemplatesWOLineItems];
GO
IF OBJECT_ID(N'[AllPointsTransportDataModelStoreContainer].[WOLineItems]', 'U') IS NOT NULL
    DROP TABLE [AllPointsTransportDataModelStoreContainer].[WOLineItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [ContactID] int IDENTITY(1,1) NOT NULL,
    [Active] bit  NULL,
    [Company] nvarchar(255)  NULL,
    [BillTo] bit  NULL,
    [Broker] bit  NULL,
    [EquipmentProvider] bit  NULL,
    [ChassisProvider] bit  NULL,
    [Location] bit  NULL,
    [RailPort] bit  NULL,
    [CYDepot] bit  NULL,
    [DallasDY] bit  NULL,
    [FtWorthDY] bit  NULL,
    [Vendor] bit  NULL,
    [Description] nvarchar(255)  NULL,
    [Contact1] nvarchar(255)  NULL,
    [Phone1] nvarchar(255)  NULL,
    [Email1] nvarchar(max)  NULL,
    [Contact2] nvarchar(255)  NULL,
    [Phone2] nvarchar(255)  NULL,
    [Email2] nvarchar(max)  NULL,
    [Fax] nvarchar(255)  NULL,
    [Address1] nvarchar(255)  NULL,
    [Address2] nvarchar(255)  NULL,
    [City] nvarchar(255)  NULL,
    [State] nvarchar(255)  NULL,
    [Zip] nvarchar(255)  NULL,
    [BillingCode] nvarchar(255)  NULL,
    [CCType] nvarchar(255)  NULL,
    [CCNum] nvarchar(255)  NULL,
    [CCExpiration] nvarchar(255)  NULL,
    [CCSecurityCode] nvarchar(255)  NULL,
    [CCCardholder] nvarchar(255)  NULL,
    [CCBillingStreet] nvarchar(255)  NULL,
    [CCBillingZip] nvarchar(255)  NULL,
    [MC] nvarchar(255)  NULL,
    [Notes] nvarchar(max)  NULL,
    [TotalCredit] decimal(19,4)  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [LastUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'Drivers'
CREATE TABLE [dbo].[Drivers] (
    [DriverID] int IDENTITY(1,1) NOT NULL,
    [DriverNo] nvarchar(255)  NULL,
    [Active] bit  NULL,
    [DriverType] nvarchar(255)  NULL,
    [EmployeePayPct] decimal(19,4)  NULL,
    [FirstName] nvarchar(255)  NULL,
    [LastName] nvarchar(255)  NULL,
    [FullName] nvarchar(255)  NULL,
    [NickName] nvarchar(255)  NULL,
    [Address1] nvarchar(255)  NULL,
    [Address2] nvarchar(255)  NULL,
    [City] nvarchar(255)  NULL,
    [State] nvarchar(255)  NULL,
    [Zip] nvarchar(255)  NULL,
    [HomePhone] nvarchar(255)  NULL,
    [MobilePhone] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [TextMessage] nvarchar(255)  NULL,
    [EmergencyContact] nvarchar(255)  NULL,
    [EmergencyPhone] nvarchar(255)  NULL,
    [SSNum] nvarchar(255)  NULL,
    [DOB] nvarchar(255)  NULL,
    [CDLNum] nvarchar(255)  NULL,
    [CDLExpiration] datetime  NULL,
    [MedicalExpiration] datetime  NULL,
    [TWICExpiration] datetime  NULL,
    [AnnualReview] datetime  NULL,
    [HireDate] datetime  NULL,
    [ResignDate] datetime  NULL,
    [ResignReason] nvarchar(max)  NULL,
    [Rehire] bit  NULL,
    [FuelCardNum] nvarchar(255)  NULL,
    [Notes] nvarchar(max)  NULL,
    [TruckNum] nvarchar(255)  NULL,
    [Color] nvarchar(255)  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [LastUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [EmployeeNo] nvarchar(255)  NULL,
    [Disabled] bit  NULL,
    [Username] nvarchar(255)  NULL,
    [Password] nvarchar(255)  NULL,
    [First] nvarchar(255)  NULL,
    [Last] nvarchar(255)  NULL,
    [Address1] nvarchar(255)  NULL,
    [Address2] nvarchar(255)  NULL,
    [City] nvarchar(255)  NULL,
    [State] nvarchar(255)  NULL,
    [Zip] nvarchar(255)  NULL,
    [Phone] nvarchar(255)  NULL,
    [Fax] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [SSNum] nvarchar(255)  NULL,
    [Salary] nvarchar(255)  NULL,
    [Hourly] nvarchar(255)  NULL,
    [Notes] nvarchar(max)  NULL,
    [Supervisor] bit  NULL,
    [scrContacts] bit  NULL,
    [scrDrivers] bit  NULL,
    [scrEmployees] bit  NULL,
    [scrTrucks] bit  NULL,
    [scrPayroll] bit  NULL,
    [scrWorkOrders] bit  NULL,
    [scrTakePayments] bit  NULL,
    [scrPaymentTypeReport] bit  NULL,
    [scrMaintenance] bit  NULL,
    [scrReminders] bit  NULL,
    [scrInvoiceReport] bit  NULL,
    [scrFuelReport] bit  NULL,
    [scrProfitLossReport] bit  NULL,
    [scrMonthlyProfitLossReport] bit  NULL,
    [scrProfitLossReportTruck] bit  NULL,
    [scrTrailers] bit  NULL,
    [scrTripLog] bit  NULL,
    [scrFuelExpenseLog] bit  NULL,
    [scrTripReport] bit  NULL,
    [scrPrePayrollReport] bit  NULL,
    [scrPayrollReport] bit  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [LastUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'RowColors'
CREATE TABLE [dbo].[RowColors] (
    [WorkOrder] decimal(18,2)  NOT NULL,
    [Color] nvarchar(255)  NULL,
    [Screen] nvarchar(255)  NULL
);
GO

-- Creating table 'RowColorsDrivers'
CREATE TABLE [dbo].[RowColorsDrivers] (
    [Driver] nvarchar(255)  NOT NULL,
    [Tab] nvarchar(100)  NULL,
    [Color] nvarchar(255)  NULL
);
GO

-- Creating table 'Schedules'
CREATE TABLE [dbo].[Schedules] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MondayDate] datetime  NULL,
    [Driver] nvarchar(255)  NULL,
    [MondayLocal] nvarchar(255)  NULL,
    [MondayRegional] nvarchar(255)  NULL,
    [TuesdayLocal] nvarchar(255)  NULL,
    [TuesdayRegional] nvarchar(255)  NULL,
    [WednesdayLocal] nvarchar(255)  NULL,
    [WednesdayRegional] nvarchar(255)  NULL,
    [ThursdayLocal] nvarchar(255)  NULL,
    [ThursdayRegional] nvarchar(255)  NULL,
    [FridayLocal] nvarchar(255)  NULL,
    [FridayRegional] nvarchar(255)  NULL,
    [SaturdayLocal] nvarchar(255)  NULL,
    [SaturdayRegional] nvarchar(255)  NULL,
    [SundayLocal] nvarchar(255)  NULL,
    [SundayRegional] nvarchar(255)  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TaskManagements'
CREATE TABLE [dbo].[TaskManagements] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AssignedTo] nvarchar(255)  NULL,
    [Priority] nvarchar(255)  NULL,
    [DueDate] datetime  NULL,
    [ProNum] nvarchar(255)  NULL,
    [Task] nvarchar(max)  NULL,
    [Complete] bit  NULL,
    [CompletedTimeStamp] datetime  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'Trucks'
CREATE TABLE [dbo].[Trucks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Active] bit  NULL,
    [TruckNum] nvarchar(255)  NOT NULL,
    [Year] nvarchar(255)  NULL,
    [Make] nvarchar(255)  NULL,
    [Model] nvarchar(255)  NULL,
    [VIN] nvarchar(255)  NULL,
    [LicensePlate] nvarchar(255)  NULL,
    [State] nvarchar(255)  NULL,
    [Color] nvarchar(255)  NULL,
    [TitleOwner] nvarchar(255)  NULL,
    [TruckPayPct] decimal(19,4)  NULL,
    [FSDeductionPct] decimal(19,4)  NULL,
    [Referral] nvarchar(255)  NULL,
    [ReferralPct] decimal(19,4)  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'WorkOrders'
CREATE TABLE [dbo].[WorkOrders] (
    [WorkOrderID] int IDENTITY(1,1) NOT NULL,
    [Completed] bit  NULL,
    [Status] nvarchar(255)  NULL,
    [InvoicedDate] datetime  NOT NULL,
    [DatePaid] datetime  NOT NULL,
    [Broker] nvarchar(255)  NULL,
    [BillTo] nvarchar(255)  NULL,
    [Container1] nvarchar(255)  NULL,
    [Seal] nvarchar(255)  NULL,
    [StreetTurn] bit  NULL,
    [EquipmentSize] nvarchar(255)  NULL,
    [Chassis] nvarchar(255)  NULL,
    [EquipmentProvider] nvarchar(255)  NULL,
    [ChassisProvider] nvarchar(255)  NULL,
    [Booking] nvarchar(255)  NULL,
    [MasterBOL] nvarchar(255)  NULL,
    [Reference] nvarchar(255)  NULL,
    [Pro] nvarchar(255)  NULL,
    [ApptNumber] nvarchar(255)  NULL,
    [Release] nvarchar(255)  NULL,
    [Weight] nvarchar(255)  NULL,
    [PieceCount] nvarchar(255)  NULL,
    [Commodity] nvarchar(255)  NULL,
    [PO] nvarchar(255)  NULL,
    [EquipmentPickup] nvarchar(255)  NULL,
    [EquipmentReturn] nvarchar(255)  NULL,
    [Origin] nvarchar(255)  NULL,
    [Destination] nvarchar(255)  NULL,
    [TypeOfMove] nvarchar(255)  NULL,
    [Duration] int  NULL,
    [StorageLFD] datetime  NOT NULL,
    [PerDiemLFD] datetime  NULL,
    [Cutoff] datetime  NOT NULL,
    [ApptTime] datetime  NOT NULL,
    [Container2] nvarchar(255)  NULL,
    [LocationHours] nvarchar(255)  NULL,
    [OutgateReceipt] datetime  NULL,
    [IngateReceipt] datetime  NULL,
    [ReadyNotification] datetime  NULL,
    [NotesInvoice] nvarchar(max)  NULL,
    [NotesPrivate] nvarchar(max)  NULL,
    [ETA] datetime  NULL,
    [LinkedProNum] nvarchar(255)  NULL,
    [InfoSymbol] nvarchar(255)  NULL,
    [BilledAmount] decimal(19,4)  NULL,
    [AcceptedByDispatch] bit  NULL,
    [RejectedByDispatch] bit  NULL,
    [POD1] bit  NULL,
    [POD2] bit  NULL,
    [BOL] bit  NULL,
    [Uploaded] bit  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL,
    [WorkOrderNo] int  NULL
);
GO

-- Creating table 'DriverPays'
CREATE TABLE [dbo].[DriverPays] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WorkOrder] int  NULL,
    [RowOrder] int  NULL,
    [Status] nvarchar(255)  NULL,
    [ToDispatch] bit  NULL,
    [ActiveLeg] bit  NULL,
    [TypeOfLoad] nvarchar(255)  NULL,
    [PayType] nvarchar(255)  NULL,
    [DispatchNotes] nvarchar(255)  NULL,
    [ApptTime] datetime  NULL,
    [DetentionStarts] datetime  NULL,
    [DepartTime] datetime  NULL,
    [ArrivalTime] datetime  NULL,
    [LineHaulAmountTruck] decimal(19,4)  NULL,
    [FSAmountTruck] decimal(19,4)  NULL,
    [TotalAmountTruck] decimal(19,4)  NULL,
    [TotalAmountEmployee] decimal(19,4)  NULL,
    [Driver] nvarchar(255)  NULL,
    [DriverRowID] int  NULL,
    [DriverType] nvarchar(255)  NULL,
    [TruckNum] nvarchar(255)  NULL,
    [TruckPayPct] decimal(19,4)  NULL,
    [FSDeductionPct] decimal(19,4)  NULL,
    [EmployeePayPct] decimal(19,4)  NULL,
    [Origin] nvarchar(255)  NULL,
    [Destination] nvarchar(255)  NULL,
    [Duration] int  NULL,
    [PrePlanSent] bit  NULL,
    [CancelSent] bit  NULL,
    [DispatchAcceptedStatus] nvarchar(255)  NULL,
    [WayBilled] bit  NULL,
    [PayDriver] bit  NULL,
    [Outgate] bit  NULL,
    [Ingate] bit  NULL,
    [POD] bit  NULL,
    [BOL] bit  NULL,
    [ReceivedDate] datetime  NULL,
    [DriverPaid] bit  NULL,
    [CommissionPaid] bit  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'Payrolls'
CREATE TABLE [dbo].[Payrolls] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Driver] nvarchar(255)  NULL,
    [PayDate] datetime  NULL,
    [PayPeriodStart] datetime  NULL,
    [PayPeriodEnd] datetime  NULL,
    [Freight] decimal(19,4)  NULL,
    [Fuel] decimal(19,4)  NULL,
    [Deductions] decimal(19,4)  NULL,
    [Total] decimal(19,4)  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'TemplatesDriverPays'
CREATE TABLE [dbo].[TemplatesDriverPays] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TemplateName] nvarchar(255)  NULL,
    [RowOrder] int  NULL,
    [ToDispatch] bit  NULL,
    [ActiveLeg] bit  NULL,
    [TypeOfLoad] nvarchar(255)  NULL,
    [PayType] nvarchar(255)  NULL,
    [DispatchNotes] nvarchar(255)  NULL,
    [ApptTime] datetime  NULL,
    [DetentionStarts] datetime  NULL,
    [DepartTime] nvarchar(255)  NULL,
    [ArrivalTime] nvarchar(255)  NULL,
    [LineHaulAmountTruck] decimal(19,4)  NULL,
    [FSAmountTruck] decimal(19,4)  NULL,
    [TotalAmountTruck] decimal(19,4)  NULL,
    [TotalAmountEmployee] decimal(19,4)  NULL,
    [Driver] nvarchar(255)  NULL,
    [DriverRowID] int  NULL,
    [DriverType] nvarchar(255)  NULL,
    [TruckNum] nvarchar(255)  NULL,
    [TruckPayPct] decimal(19,4)  NULL,
    [FSDeductionPct] decimal(19,4)  NULL,
    [EmployeePayPct] decimal(19,4)  NULL,
    [Origin] nvarchar(255)  NULL,
    [Destination] nvarchar(255)  NULL,
    [Duration] int  NULL,
    [PrePlanSent] bit  NULL,
    [DispatchAcceptedStatus] nvarchar(255)  NULL,
    [WayBilled] bit  NULL,
    [PayDriver] bit  NULL,
    [Outgate] bit  NULL,
    [Ingate] bit  NULL,
    [POD] bit  NULL,
    [BOL] bit  NULL,
    [ReceivedDate] datetime  NULL,
    [DriverPaid] bit  NULL,
    [CommissionPaid] bit  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'TemplatesWOes'
CREATE TABLE [dbo].[TemplatesWOes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TemplateName] nvarchar(255)  NOT NULL,
    [BillTo] nvarchar(255)  NULL,
    [Broker] nvarchar(255)  NULL,
    [TypeOfMove] nvarchar(255)  NULL,
    [EquipmentProvider] nvarchar(255)  NULL,
    [EquipmentSize] nvarchar(255)  NULL,
    [ChassisProvider] nvarchar(255)  NULL,
    [EquipmentPickup] nvarchar(255)  NULL,
    [EquipmentReturn] nvarchar(255)  NULL,
    [LocationHours] nvarchar(255)  NULL,
    [Origin] nvarchar(255)  NULL,
    [Destination] nvarchar(255)  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'TemplatesWOLineItems'
CREATE TABLE [dbo].[TemplatesWOLineItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TemplateName] nvarchar(255)  NULL,
    [RowOrder] int  NULL,
    [BillingItem] nvarchar(255)  NULL,
    [Description] nvarchar(255)  NULL,
    [Vendor] nvarchar(255)  NULL,
    [VendorReference] nvarchar(255)  NULL,
    [Quantity] decimal(19,4)  NULL,
    [Rate] decimal(19,4)  NULL,
    [Amount] decimal(19,4)  NULL,
    [Fee] bit  NULL,
    [PayDriver] bit  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'WOLineItems'
CREATE TABLE [dbo].[WOLineItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WorkOrder] int  NULL,
    [RowOrder] int  NULL,
    [BillingItem] nvarchar(255)  NULL,
    [Description] nvarchar(255)  NULL,
    [Vendor] nvarchar(255)  NULL,
    [VendorReference] nvarchar(255)  NULL,
    [Quantity] decimal(19,4)  NULL,
    [Rate] decimal(19,4)  NULL,
    [Amount] decimal(19,4)  NULL,
    [Fee] bit  NULL,
    [PayDriver] bit  NULL,
    [DateCreated] datetime  NULL,
    [CreatedBy] nvarchar(255)  NULL,
    [DateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(255)  NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Item] nvarchar(255)  NOT NULL,
    [Value] nvarchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ContactID] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([ContactID] ASC);
GO

-- Creating primary key on [DriverID] in table 'Drivers'
ALTER TABLE [dbo].[Drivers]
ADD CONSTRAINT [PK_Drivers]
    PRIMARY KEY CLUSTERED ([DriverID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [WorkOrder] in table 'RowColors'
ALTER TABLE [dbo].[RowColors]
ADD CONSTRAINT [PK_RowColors]
    PRIMARY KEY CLUSTERED ([WorkOrder] ASC);
GO

-- Creating primary key on [Driver] in table 'RowColorsDrivers'
ALTER TABLE [dbo].[RowColorsDrivers]
ADD CONSTRAINT [PK_RowColorsDrivers]
    PRIMARY KEY CLUSTERED ([Driver] ASC);
GO

-- Creating primary key on [ID] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [PK_Schedules]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'TaskManagements'
ALTER TABLE [dbo].[TaskManagements]
ADD CONSTRAINT [PK_TaskManagements]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [TruckNum] in table 'Trucks'
ALTER TABLE [dbo].[Trucks]
ADD CONSTRAINT [PK_Trucks]
    PRIMARY KEY CLUSTERED ([TruckNum] ASC);
GO

-- Creating primary key on [WorkOrderID] in table 'WorkOrders'
ALTER TABLE [dbo].[WorkOrders]
ADD CONSTRAINT [PK_WorkOrders]
    PRIMARY KEY CLUSTERED ([WorkOrderID] ASC);
GO

-- Creating primary key on [ID] in table 'DriverPays'
ALTER TABLE [dbo].[DriverPays]
ADD CONSTRAINT [PK_DriverPays]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Payrolls'
ALTER TABLE [dbo].[Payrolls]
ADD CONSTRAINT [PK_Payrolls]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplatesDriverPays'
ALTER TABLE [dbo].[TemplatesDriverPays]
ADD CONSTRAINT [PK_TemplatesDriverPays]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [TemplateName] in table 'TemplatesWOes'
ALTER TABLE [dbo].[TemplatesWOes]
ADD CONSTRAINT [PK_TemplatesWOes]
    PRIMARY KEY CLUSTERED ([ID], [TemplateName] ASC);
GO

-- Creating primary key on [ID] in table 'TemplatesWOLineItems'
ALTER TABLE [dbo].[TemplatesWOLineItems]
ADD CONSTRAINT [PK_TemplatesWOLineItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WOLineItems'
ALTER TABLE [dbo].[WOLineItems]
ADD CONSTRAINT [PK_WOLineItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [Item] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([ID], [Item] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------