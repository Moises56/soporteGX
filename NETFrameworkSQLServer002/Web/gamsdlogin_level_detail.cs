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
   public class gamsdlogin_level_detail : GXProcedure
   {
      public gamsdlogin_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdlogin_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDLogin_Level_DetailSdt aP1_GXM4GAMSDLogin_Level_DetailSdt )
      {
         this.AV14gxid = aP0_gxid;
         this.AV21GXM4GAMSDLogin_Level_DetailSdt = new SdtGAMSDLogin_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM4GAMSDLogin_Level_DetailSdt=this.AV21GXM4GAMSDLogin_Level_DetailSdt;
      }

      public SdtGAMSDLogin_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM4GAMSDLogin_Level_DetailSdt);
         return AV21GXM4GAMSDLogin_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDLogin_Level_DetailSdt aP1_GXM4GAMSDLogin_Level_DetailSdt )
      {
         gamsdlogin_level_detail objgamsdlogin_level_detail;
         objgamsdlogin_level_detail = new gamsdlogin_level_detail();
         objgamsdlogin_level_detail.AV14gxid = aP0_gxid;
         objgamsdlogin_level_detail.AV21GXM4GAMSDLogin_Level_DetailSdt = new SdtGAMSDLogin_Level_DetailSdt(context) ;
         objgamsdlogin_level_detail.context.SetSubmitInitialConfig(context);
         objgamsdlogin_level_detail.initialize();
         Submit( executePrivateCatch,objgamsdlogin_level_detail);
         aP1_GXM4GAMSDLogin_Level_DetailSdt=this.AV21GXM4GAMSDLogin_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamsdlogin_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV14gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "name") == 0 )
            {
               Gxdynprop1 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"name");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "email") == 0 )
            {
               Gxdynprop2 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"email");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "namema") == 0 )
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
         AV21GXM4GAMSDLogin_Level_DetailSdt.gxTpr_Username = AV10UserName;
         AV21GXM4GAMSDLogin_Level_DetailSdt.gxTpr_Password = AV12Password;
         AV21GXM4GAMSDLogin_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV21GXM4GAMSDLogin_Level_DetailSdt = new SdtGAMSDLogin_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         Gxdynprop1 = "";
         Gxdynprop = "";
         Gxdynprop2 = "";
         Gxdynprop3 = "";
         AV10UserName = "";
         AV12Password = "";
         /* GeneXus formulas. */
      }

      private int AV14gxid ;
      private string Gxids ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private string Gxdynprop3 ;
      private string AV12Password ;
      private string Gxdynprop ;
      private string AV10UserName ;
      private SdtGAMSDLogin_Level_DetailSdt aP1_GXM4GAMSDLogin_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV13GAMRepository ;
      private SdtGAMSDLogin_Level_DetailSdt AV21GXM4GAMSDLogin_Level_DetailSdt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gamsdlogin_level_detail_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gamsdlogin_level_detail_services : GxRestService
   {
      [OperationContract(Name = "GAMSDLogin_Level_Detail" )]
      [WebInvoke(Method =  "GET" ,
      	BodyStyle =  WebMessageBodyStyle.Bare  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/?gxid={gxid}")]
      public SdtGAMSDLogin_Level_DetailSdt_RESTInterface execute( string gxid )
      {
         SdtGAMSDLogin_Level_DetailSdt_RESTInterface GXM4GAMSDLogin_Level_DetailSdt = new SdtGAMSDLogin_Level_DetailSdt_RESTInterface();
         try
         {
            if ( ! ProcessHeaders("gamsdlogin_level_detail") )
            {
               return null ;
            }
            gamsdlogin_level_detail worker = new gamsdlogin_level_detail(context);
            worker.IsMain = RunAsMain ;
            int gxrgxid = 0;
            gxrgxid = (int)(Math.Round(NumberUtil.Val( (string)(gxid), "."), 18, MidpointRounding.ToEven));
            SdtGAMSDLogin_Level_DetailSdt gxrGXM4GAMSDLogin_Level_DetailSdt = GXM4GAMSDLogin_Level_DetailSdt.sdt;
            worker.execute(gxrgxid,out gxrGXM4GAMSDLogin_Level_DetailSdt );
            worker.cleanup( );
            GXM4GAMSDLogin_Level_DetailSdt = new SdtGAMSDLogin_Level_DetailSdt_RESTInterface(gxrGXM4GAMSDLogin_Level_DetailSdt) ;
            return GXM4GAMSDLogin_Level_DetailSdt ;
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
