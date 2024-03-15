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
   public class gamsdnotauthorized_level_detail : GXProcedure
   {
      public gamsdnotauthorized_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdnotauthorized_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDNotAuthorized_Level_DetailSdt aP1_GXM4GAMSDNotAuthorized_Level_DetailSdt )
      {
         this.AV12gxid = aP0_gxid;
         this.AV19GXM4GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM4GAMSDNotAuthorized_Level_DetailSdt=this.AV19GXM4GAMSDNotAuthorized_Level_DetailSdt;
      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM4GAMSDNotAuthorized_Level_DetailSdt);
         return AV19GXM4GAMSDNotAuthorized_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDNotAuthorized_Level_DetailSdt aP1_GXM4GAMSDNotAuthorized_Level_DetailSdt )
      {
         gamsdnotauthorized_level_detail objgamsdnotauthorized_level_detail;
         objgamsdnotauthorized_level_detail = new gamsdnotauthorized_level_detail();
         objgamsdnotauthorized_level_detail.AV12gxid = aP0_gxid;
         objgamsdnotauthorized_level_detail.AV19GXM4GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt(context) ;
         objgamsdnotauthorized_level_detail.context.SetSubmitInitialConfig(context);
         objgamsdnotauthorized_level_detail.initialize();
         Submit( executePrivateCatch,objgamsdnotauthorized_level_detail);
         aP1_GXM4GAMSDNotAuthorized_Level_DetailSdt=this.AV19GXM4GAMSDNotAuthorized_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamsdnotauthorized_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV12gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV11GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( StringUtil.StrCmp(AV11GAMRepository.gxTpr_Useridentification, "name") == 0 )
            {
               Gxdynprop1 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"name");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV11GAMRepository.gxTpr_Useridentification, "email") == 0 )
            {
               Gxdynprop2 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"email");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV11GAMRepository.gxTpr_Useridentification, "namema") == 0 )
            {
               Gxdynprop3 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"namema");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop3) + "\"]";
            }
            Gxwebsession.Set(Gxids+"gxvar_Username", AV10UserName);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV10UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
         }
         AV19GXM4GAMSDNotAuthorized_Level_DetailSdt.gxTpr_Username = AV10UserName;
         AV19GXM4GAMSDNotAuthorized_Level_DetailSdt.gxTpr_Password = AV9Password;
         AV19GXM4GAMSDNotAuthorized_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
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
         AV19GXM4GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV11GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         Gxdynprop1 = "";
         Gxdynprop = "";
         Gxdynprop2 = "";
         Gxdynprop3 = "";
         AV10UserName = "";
         AV9Password = "";
         /* GeneXus formulas. */
      }

      private int AV12gxid ;
      private string Gxids ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private string Gxdynprop3 ;
      private string AV9Password ;
      private string Gxdynprop ;
      private string AV10UserName ;
      private SdtGAMSDNotAuthorized_Level_DetailSdt aP1_GXM4GAMSDNotAuthorized_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV11GAMRepository ;
      private SdtGAMSDNotAuthorized_Level_DetailSdt AV19GXM4GAMSDNotAuthorized_Level_DetailSdt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gamsdnotauthorized_level_detail_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gamsdnotauthorized_level_detail_services : GxRestService
   {
      [OperationContract(Name = "GAMSDNotAuthorized_Level_Detail" )]
      [WebInvoke(Method =  "GET" ,
      	BodyStyle =  WebMessageBodyStyle.Bare  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/?gxid={gxid}")]
      public SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface execute( string gxid )
      {
         SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface GXM4GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface();
         try
         {
            if ( ! ProcessHeaders("gamsdnotauthorized_level_detail") )
            {
               return null ;
            }
            gamsdnotauthorized_level_detail worker = new gamsdnotauthorized_level_detail(context);
            worker.IsMain = RunAsMain ;
            int gxrgxid = 0;
            gxrgxid = (int)(Math.Round(NumberUtil.Val( (string)(gxid), "."), 18, MidpointRounding.ToEven));
            SdtGAMSDNotAuthorized_Level_DetailSdt gxrGXM4GAMSDNotAuthorized_Level_DetailSdt = GXM4GAMSDNotAuthorized_Level_DetailSdt.sdt;
            worker.execute(gxrgxid,out gxrGXM4GAMSDNotAuthorized_Level_DetailSdt );
            worker.cleanup( );
            GXM4GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface(gxrGXM4GAMSDNotAuthorized_Level_DetailSdt) ;
            return GXM4GAMSDNotAuthorized_Level_DetailSdt ;
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
         return null ;
      }

   }

}
