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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class addandgetpermissionresource : GXProcedure
   {
      public addandgetpermissionresource( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public addandgetpermissionresource( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtK2BActivity aP0_Activity ,
                           long aP1_ApplicationId ,
                           out string aP2_PermissionResourceGUID )
      {
         this.AV8Activity = aP0_Activity;
         this.AV15ApplicationId = aP1_ApplicationId;
         this.AV13PermissionResourceGUID = "" ;
         initialize();
         executePrivate();
         aP2_PermissionResourceGUID=this.AV13PermissionResourceGUID;
      }

      public string executeUdp( SdtK2BActivity aP0_Activity ,
                                long aP1_ApplicationId )
      {
         execute(aP0_Activity, aP1_ApplicationId, out aP2_PermissionResourceGUID);
         return AV13PermissionResourceGUID ;
      }

      public void executeSubmit( SdtK2BActivity aP0_Activity ,
                                 long aP1_ApplicationId ,
                                 out string aP2_PermissionResourceGUID )
      {
         addandgetpermissionresource objaddandgetpermissionresource;
         objaddandgetpermissionresource = new addandgetpermissionresource();
         objaddandgetpermissionresource.AV8Activity = aP0_Activity;
         objaddandgetpermissionresource.AV15ApplicationId = aP1_ApplicationId;
         objaddandgetpermissionresource.AV13PermissionResourceGUID = "" ;
         objaddandgetpermissionresource.context.SetSubmitInitialConfig(context);
         objaddandgetpermissionresource.initialize();
         Submit( executePrivateCatch,objaddandgetpermissionresource);
         aP2_PermissionResourceGUID=this.AV13PermissionResourceGUID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((addandgetpermissionresource)stateInfo).executePrivate();
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
         GXt_char1 = AV12Permission;
         new GeneXus.Programs.k2bfsg.getgampermissionnameforactivity(context ).execute(  AV8Activity, out  GXt_char1) ;
         AV12Permission = GXt_char1;
         AV13PermissionResourceGUID = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Permission)) )
         {
            AV16GAMApplication.load( AV15ApplicationId);
            AV9ApplicationPermission = AV16GAMApplication.getpermissionbyname(AV12Permission, out  AV10Errors);
            if ( ( AV10Errors.Count == 1 ) && ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 153 ) )
            {
               AV9ApplicationPermission.gxTpr_Name = AV12Permission;
               AV9ApplicationPermission.gxTpr_Description = AV12Permission;
               AV9ApplicationPermission.gxTpr_Accesstype = "R";
               AV11IsOK = AV16GAMApplication.addpermission(AV9ApplicationPermission, out  AV10Errors);
               if ( AV11IsOK )
               {
                  context.CommitDataStores("k2bfsg.addandgetpermissionresource",pr_default);
               }
            }
            AV13PermissionResourceGUID = AV9ApplicationPermission.gxTpr_Guid;
         }
         this.cleanup();
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
         AV13PermissionResourceGUID = "";
         AV12Permission = "";
         GXt_char1 = "";
         AV16GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV9ApplicationPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addandgetpermissionresource__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.addandgetpermissionresource__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long AV15ApplicationId ;
      private string AV13PermissionResourceGUID ;
      private string AV12Permission ;
      private string GXt_char1 ;
      private bool AV11IsOK ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string aP2_PermissionResourceGUID ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private SdtK2BActivity AV8Activity ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV9ApplicationPermission ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV16GAMApplication ;
   }

   public class addandgetpermissionresource__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class addandgetpermissionresource__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
