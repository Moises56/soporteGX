using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bisauthorizedactivitylist : GXProcedure
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "k2bisauthorizedactivitylist_Services_Execute" ;
         }

      }

      public k2bisauthorizedactivitylist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bisauthorizedactivitylist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList )
      {
         this.AV9activityList = aP0_activityList;
         initialize();
         executePrivate();
         aP0_activityList=this.AV9activityList;
      }

      public GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> executeUdp( )
      {
         execute(ref aP0_activityList);
         return AV9activityList ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList )
      {
         k2bisauthorizedactivitylist objk2bisauthorizedactivitylist;
         objk2bisauthorizedactivitylist = new k2bisauthorizedactivitylist();
         objk2bisauthorizedactivitylist.AV9activityList = aP0_activityList;
         objk2bisauthorizedactivitylist.context.SetSubmitInitialConfig(context);
         objk2bisauthorizedactivitylist.initialize();
         Submit( executePrivateCatch,objk2bisauthorizedactivitylist);
         aP0_activityList=this.AV9activityList;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bisauthorizedactivitylist)stateInfo).executePrivate();
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
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV9activityList.Count )
         {
            AV8activity = ((SdtK2BActivityList_K2BActivityListItem)AV9activityList.Item(AV12GXV1));
            if ( ( ( StringUtil.StrCmp(AV8activity.gxTpr_Activity.gxTpr_Pgmname, "WWRepositories") == 0 ) || ( StringUtil.StrCmp(AV8activity.gxTpr_Activity.gxTpr_Pgmname, "K2BFSG.WWRepositories") == 0 ) ) && ( StringUtil.StrCmp(AV8activity.gxTpr_Activity.gxTpr_Useractivitytype, "K2BSecurity") == 0 ) )
            {
               AV8activity.gxTpr_Isauthorized = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV11Errors);
            }
            else
            {
               GXt_char1 = AV10activityToCheck;
               new GeneXus.Programs.k2bfsg.getgampermissionnameforactivity(context ).execute(  AV8activity.gxTpr_Activity, out  GXt_char1) ;
               AV10activityToCheck = GXt_char1;
               AV8activity.gxTpr_Isauthorized = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).checkpermission(AV10activityToCheck);
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV8activity = new SdtK2BActivityList_K2BActivityListItem(context);
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10activityToCheck = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private string AV10activityToCheck ;
      private string GXt_char1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV9activityList ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private SdtK2BActivityList_K2BActivityListItem AV8activity ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.k2bisauthorizedactivitylist_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class k2bisauthorizedactivitylist_services : GxRestService
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

      [OperationContract(Name = "K2BIsAuthorizedActivityList" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( ref GxGenericCollection<SdtK2BActivityList_K2BActivityListItem_RESTInterface> activityList )
      {
         try
         {
            permissionPrefix = "k2bisauthorizedactivitylist_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("k2bisauthorizedactivitylist") )
            {
               return  ;
            }
            k2bisauthorizedactivitylist worker = new k2bisauthorizedactivitylist(context);
            worker.IsMain = RunAsMain ;
            GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> gxractivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>();
            activityList.LoadCollection(gxractivityList);
            worker.execute(ref gxractivityList );
            worker.cleanup( );
            activityList = new GxGenericCollection<SdtK2BActivityList_K2BActivityListItem_RESTInterface>(gxractivityList) ;
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
