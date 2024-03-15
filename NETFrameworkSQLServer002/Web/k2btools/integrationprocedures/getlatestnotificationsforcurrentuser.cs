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
namespace GeneXus.Programs.k2btools.integrationprocedures {
   public class getlatestnotificationsforcurrentuser : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public getlatestnotificationsforcurrentuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getlatestnotificationsforcurrentuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "test") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> aP0_Gxm2rootcol )
      {
         getlatestnotificationsforcurrentuser objgetlatestnotificationsforcurrentuser;
         objgetlatestnotificationsforcurrentuser = new getlatestnotificationsforcurrentuser();
         objgetlatestnotificationsforcurrentuser.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification>( context, "Notification", "test") ;
         objgetlatestnotificationsforcurrentuser.context.SetSubmitInitialConfig(context);
         objgetlatestnotificationsforcurrentuser.initialize();
         Submit( executePrivateCatch,objgetlatestnotificationsforcurrentuser);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getlatestnotificationsforcurrentuser)stateInfo).executePrivate();
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
         Gxm1webnotificationsdt = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         Gxm2rootcol.Add(Gxm1webnotificationsdt, 0);
         Gxm1webnotificationsdt.gxTpr_Notificationid = 1;
         Gxm1webnotificationsdt.gxTpr_Notificationicon = context.convertURL( (string)(context.GetImagePath( "d92c0485-557f-42b9-aa27-93baa220f7e4", "", context.GetTheme( ))));
         Gxm1webnotificationsdt.gxTpr_Notificationactioncaption = context.GetMessage( "View", "");
         GXt_char1 = "";
         new k2bgetusercode(context ).execute( out  GXt_char1) ;
         Gxm1webnotificationsdt.gxTpr_Notificationusercode = GXt_char1;
         Gxm1webnotificationsdt.gxTpr_Notificationtext = context.GetMessage( "This is a sample notification", "");
         Gxm1webnotificationsdt.gxTpr_Eventcreationdatetime = DateTimeUtil.ServerNowMs( context, pr_default);
         Gxm1webnotificationsdt.gxTpr_Eventtargeturl = "";
         Gxm1webnotificationsdt.gxTpr_Notificationisread = true;
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
         Gxm1webnotificationsdt = new GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2btools.integrationprocedures.getlatestnotificationsforcurrentuser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification> Gxm2rootcol ;
      private GeneXus.Programs.k2btools.integrationprocedures.SdtWebNotificationSDT_Notification Gxm1webnotificationsdt ;
   }

   public class getlatestnotificationsforcurrentuser__default : DataStoreHelperBase, IDataStoreHelper
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
