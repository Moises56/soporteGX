using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportwwsoporte : GXProcedure
   {
      public exportwwsoporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public exportwwsoporte( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_hostName_Filter ,
                           string aP1_K2BToolsGenericSearchField ,
                           short aP2_OrderedBy ,
                           out string aP3_OutFile )
      {
         this.AV21hostName_Filter = aP0_hostName_Filter;
         this.AV20K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         this.AV15OrderedBy = aP2_OrderedBy;
         this.AV13OutFile = "" ;
         initialize();
         executePrivate();
         aP3_OutFile=this.AV13OutFile;
      }

      public string executeUdp( string aP0_hostName_Filter ,
                                string aP1_K2BToolsGenericSearchField ,
                                short aP2_OrderedBy )
      {
         execute(aP0_hostName_Filter, aP1_K2BToolsGenericSearchField, aP2_OrderedBy, out aP3_OutFile);
         return AV13OutFile ;
      }

      public void executeSubmit( string aP0_hostName_Filter ,
                                 string aP1_K2BToolsGenericSearchField ,
                                 short aP2_OrderedBy ,
                                 out string aP3_OutFile )
      {
         exportwwsoporte objexportwwsoporte;
         objexportwwsoporte = new exportwwsoporte();
         objexportwwsoporte.AV21hostName_Filter = aP0_hostName_Filter;
         objexportwwsoporte.AV20K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         objexportwwsoporte.AV15OrderedBy = aP2_OrderedBy;
         objexportwwsoporte.AV13OutFile = "" ;
         objexportwwsoporte.context.SetSubmitInitialConfig(context);
         objexportwwsoporte.initialize();
         Submit( executePrivateCatch,objexportwwsoporte);
         aP3_OutFile=this.AV13OutFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwsoporte)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new k2bgetcontext(context ).execute( out  AV29Context) ;
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13OutFile = GxDirectory.TemporaryFilesPath + AV14File.Separator + "ExportWWsoporte-" + Guid.NewGuid( ).ToString() + ".xlsx";
         AV8ExcelDocument.Open(AV13OutFile);
         AV8ExcelDocument.AutoFit = 1;
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Clear();
         AV9CellRow = 1;
         AV10FirstColumn = 1;
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Size = 15;
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn, 1, 1).Text = "soportes";
         AV9CellRow = (int)(AV9CellRow+4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20K2BToolsGenericSearchField)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Search";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = AV20K2BToolsGenericSearchField;
            AV9CellRow = (int)(AV9CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21hostName_Filter)) )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+0, 1, 1).Text = "Name";
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV21hostName_Filter);
            AV9CellRow = (int)(AV9CellRow+1);
         }
         AV9CellRow = (int)(AV9CellRow+3);
         AV11ColumnIndex = 0;
         if ( AV22GridColumnVisible_soporteID )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "ID";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV23GridColumnVisible_hostName )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "HostName";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV24GridColumnVisible_serie )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Serie";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV25GridColumnVisible_ipv4 )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "IPV4";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV26GridColumnVisible_mac )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "MAC";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV27GridColumnVisible_modelo )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Modelo";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV28GridColumnVisible_nombreUsuario )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "NombreUsuario";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         if ( AV30GridColumnVisible_nombreDepartamento )
         {
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Bold = 1;
            AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = "Departamento";
            AV11ColumnIndex = (short)(AV11ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV21hostName_Filter ,
                                              AV20K2BToolsGenericSearchField ,
                                              A5hostName ,
                                              A4soporteID ,
                                              A10ipv4 ,
                                              A11mac ,
                                              A12modelo ,
                                              A13nombreUsuario ,
                                              A14nombreDepartamento ,
                                              AV15OrderedBy } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV21hostName_Filter = StringUtil.Concat( StringUtil.RTrim( AV21hostName_Filter), "%", "");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         lV20K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV20K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003A2 */
         pr_default.execute(0, new Object[] {lV21hostName_Filter, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField, lV20K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14nombreDepartamento = P003A2_A14nombreDepartamento[0];
            A13nombreUsuario = P003A2_A13nombreUsuario[0];
            A12modelo = P003A2_A12modelo[0];
            A11mac = P003A2_A11mac[0];
            A10ipv4 = P003A2_A10ipv4[0];
            A9serie = P003A2_A9serie[0];
            A4soporteID = P003A2_A4soporteID[0];
            A5hostName = P003A2_A5hostName[0];
            AV9CellRow = (int)(AV9CellRow+1);
            AV11ColumnIndex = 0;
            if ( AV22GridColumnVisible_soporteID )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Number = A4soporteID;
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV23GridColumnVisible_hostName )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A5hostName);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV24GridColumnVisible_serie )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A9serie);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV25GridColumnVisible_ipv4 )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A10ipv4);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV26GridColumnVisible_mac )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A11mac);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV27GridColumnVisible_modelo )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A12modelo);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV28GridColumnVisible_nombreUsuario )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A13nombreUsuario);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            if ( AV30GridColumnVisible_nombreDepartamento )
            {
               AV8ExcelDocument.get_Cells(AV9CellRow, AV10FirstColumn+AV11ColumnIndex, 1, 1).Text = StringUtil.RTrim( A14nombreDepartamento);
               AV11ColumnIndex = (short)(AV11ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV8ExcelDocument.ErrCode != 0 )
         {
            AV13OutFile = "";
            AV12ErrorMessage = AV8ExcelDocument.ErrDescription;
            AV8ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S131 ();
         if (returnInSub) return;
         new k2bloadgridconfiguration(context ).execute(  "WWsoporte",  "Grid", ref  AV16GridConfiguration) ;
         AV18GridColumns = AV16GridConfiguration.gxTpr_Gridcolumns;
         AV22GridColumnVisible_soporteID = true;
         AV23GridColumnVisible_hostName = true;
         AV24GridColumnVisible_serie = true;
         AV25GridColumnVisible_ipv4 = true;
         AV26GridColumnVisible_mac = true;
         AV27GridColumnVisible_modelo = true;
         AV28GridColumnVisible_nombreUsuario = true;
         AV30GridColumnVisible_nombreDepartamento = true;
         new k2bsavegridconfiguration(context ).execute(  "WWsoporte",  "Grid",  AV16GridConfiguration,  false) ;
         AV18GridColumns = AV16GridConfiguration.gxTpr_Gridcolumns;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV18GridColumns.Count )
         {
            AV19GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV18GridColumns.Item(AV32GXV1));
            if ( ! AV19GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "soporteID") == 0 )
               {
                  AV22GridColumnVisible_soporteID = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "hostName") == 0 )
               {
                  AV23GridColumnVisible_hostName = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "serie") == 0 )
               {
                  AV24GridColumnVisible_serie = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "ipv4") == 0 )
               {
                  AV25GridColumnVisible_ipv4 = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "mac") == 0 )
               {
                  AV26GridColumnVisible_mac = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "modelo") == 0 )
               {
                  AV27GridColumnVisible_modelo = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "nombreUsuario") == 0 )
               {
                  AV28GridColumnVisible_nombreUsuario = false;
               }
               else if ( StringUtil.StrCmp(AV19GridColumn.gxTpr_Attributename, "nombreDepartamento") == 0 )
               {
                  AV30GridColumnVisible_nombreDepartamento = false;
               }
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV18GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "test");
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "soporteID";
         AV19GridColumn.gxTpr_Columntitle = "ID";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "hostName";
         AV19GridColumn.gxTpr_Columntitle = "HostName";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "serie";
         AV19GridColumn.gxTpr_Columntitle = "Serie";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "ipv4";
         AV19GridColumn.gxTpr_Columntitle = "IPV4";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "mac";
         AV19GridColumn.gxTpr_Columntitle = "MAC";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "modelo";
         AV19GridColumn.gxTpr_Columntitle = "Modelo";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "nombreUsuario";
         AV19GridColumn.gxTpr_Columntitle = "NombreUsuario";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV19GridColumn.gxTpr_Attributename = "nombreDepartamento";
         AV19GridColumn.gxTpr_Columntitle = "Departamento";
         AV19GridColumn.gxTpr_Showattribute = true;
         AV18GridColumns.Add(AV19GridColumn, 0);
         AV16GridConfiguration.gxTpr_Gridcolumns = AV18GridColumns;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV13OutFile = "";
         AV29Context = new SdtK2BContext(context);
         AV14File = new GxFile(context.GetPhysicalPath());
         AV8ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV21hostName_Filter = "";
         lV20K2BToolsGenericSearchField = "";
         A5hostName = "";
         A10ipv4 = "";
         A11mac = "";
         A12modelo = "";
         A13nombreUsuario = "";
         A14nombreDepartamento = "";
         P003A2_A14nombreDepartamento = new string[] {""} ;
         P003A2_A13nombreUsuario = new string[] {""} ;
         P003A2_A12modelo = new string[] {""} ;
         P003A2_A11mac = new string[] {""} ;
         P003A2_A10ipv4 = new string[] {""} ;
         P003A2_A9serie = new string[] {""} ;
         P003A2_A4soporteID = new int[1] ;
         P003A2_A5hostName = new string[] {""} ;
         A9serie = "";
         AV12ErrorMessage = "";
         AV16GridConfiguration = new SdtK2BGridConfiguration(context);
         AV18GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "test");
         AV19GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwsoporte__default(),
            new Object[][] {
                new Object[] {
               P003A2_A14nombreDepartamento, P003A2_A13nombreUsuario, P003A2_A12modelo, P003A2_A11mac, P003A2_A10ipv4, P003A2_A9serie, P003A2_A4soporteID, P003A2_A5hostName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15OrderedBy ;
      private short AV11ColumnIndex ;
      private int AV9CellRow ;
      private int AV10FirstColumn ;
      private int A4soporteID ;
      private int AV32GXV1 ;
      private string AV20K2BToolsGenericSearchField ;
      private string scmdbuf ;
      private string lV20K2BToolsGenericSearchField ;
      private bool returnInSub ;
      private bool AV22GridColumnVisible_soporteID ;
      private bool AV23GridColumnVisible_hostName ;
      private bool AV24GridColumnVisible_serie ;
      private bool AV25GridColumnVisible_ipv4 ;
      private bool AV26GridColumnVisible_mac ;
      private bool AV27GridColumnVisible_modelo ;
      private bool AV28GridColumnVisible_nombreUsuario ;
      private bool AV30GridColumnVisible_nombreDepartamento ;
      private string AV21hostName_Filter ;
      private string AV13OutFile ;
      private string lV21hostName_Filter ;
      private string A5hostName ;
      private string A10ipv4 ;
      private string A11mac ;
      private string A12modelo ;
      private string A13nombreUsuario ;
      private string A14nombreDepartamento ;
      private string A9serie ;
      private string AV12ErrorMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003A2_A14nombreDepartamento ;
      private string[] P003A2_A13nombreUsuario ;
      private string[] P003A2_A12modelo ;
      private string[] P003A2_A11mac ;
      private string[] P003A2_A10ipv4 ;
      private string[] P003A2_A9serie ;
      private int[] P003A2_A4soporteID ;
      private string[] P003A2_A5hostName ;
      private string aP3_OutFile ;
      private ExcelDocumentI AV8ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV18GridColumns ;
      private GxFile AV14File ;
      private SdtK2BGridConfiguration AV16GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV19GridColumn ;
      private SdtK2BContext AV29Context ;
   }

   public class exportwwsoporte__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003A2( IGxContext context ,
                                             string AV21hostName_Filter ,
                                             string AV20K2BToolsGenericSearchField ,
                                             string A5hostName ,
                                             int A4soporteID ,
                                             string A10ipv4 ,
                                             string A11mac ,
                                             string A12modelo ,
                                             string A13nombreUsuario ,
                                             string A14nombreDepartamento ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [nombreDepartamento], [nombreUsuario], [modelo], [mac], [ipv4], [serie], [soporteID], [hostName] FROM [soporte]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21hostName_Filter)) )
         {
            AddWhere(sWhereString, "([hostName] like @lV21hostName_Filter)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([soporteID] AS decimal(9,0))) like '%' + @lV20K2BToolsGenericSearchField + '%' or [hostName] like '%' + @lV20K2BToolsGenericSearchField + '%' or [serie] like '%' + @lV20K2BToolsGenericSearchField + '%' or [ipv4] like '%' + @lV20K2BToolsGenericSearchField + '%' or [mac] like '%' + @lV20K2BToolsGenericSearchField + '%' or [modelo] like '%' + @lV20K2BToolsGenericSearchField + '%' or [nombreUsuario] like '%' + @lV20K2BToolsGenericSearchField + '%' or [nombreDepartamento] like '%' + @lV20K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [soporteID]";
         }
         else if ( AV15OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [soporteID] DESC";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [hostName]";
         }
         else if ( AV15OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [hostName] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P003A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003A2;
          prmP003A2 = new Object[] {
          new ParDef("@lV21hostName_Filter",GXType.NVarChar,40,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV20K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003A2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
