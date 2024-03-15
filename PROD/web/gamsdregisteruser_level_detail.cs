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
   public class gamsdregisteruser_level_detail : GXProcedure
   {
      public gamsdregisteruser_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdregisteruser_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDRegisterUser_Level_DetailSdt aP1_GXM1GAMSDRegisterUser_Level_DetailSdt )
      {
         this.AV14gxid = aP0_gxid;
         this.AV18GXM1GAMSDRegisterUser_Level_DetailSdt = new SdtGAMSDRegisterUser_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM1GAMSDRegisterUser_Level_DetailSdt=this.AV18GXM1GAMSDRegisterUser_Level_DetailSdt;
      }

      public SdtGAMSDRegisterUser_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1GAMSDRegisterUser_Level_DetailSdt);
         return AV18GXM1GAMSDRegisterUser_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDRegisterUser_Level_DetailSdt aP1_GXM1GAMSDRegisterUser_Level_DetailSdt )
      {
         gamsdregisteruser_level_detail objgamsdregisteruser_level_detail;
         objgamsdregisteruser_level_detail = new gamsdregisteruser_level_detail();
         objgamsdregisteruser_level_detail.AV14gxid = aP0_gxid;
         objgamsdregisteruser_level_detail.AV18GXM1GAMSDRegisterUser_Level_DetailSdt = new SdtGAMSDRegisterUser_Level_DetailSdt(context) ;
         objgamsdregisteruser_level_detail.context.SetSubmitInitialConfig(context);
         objgamsdregisteruser_level_detail.initialize();
         Submit( executePrivateCatch,objgamsdregisteruser_level_detail);
         aP1_GXM1GAMSDRegisterUser_Level_DetailSdt=this.AV18GXM1GAMSDRegisterUser_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamsdregisteruser_level_detail)stateInfo).executePrivate();
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
            if ( StringUtil.StrCmp(AV13GAMRepository.gxTpr_Useridentification, "email") == 0 )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Visible\",\"" + "False" + "\"]";
            }
            Gxwebsession.Set(Gxids+"gxvar_Username", AV12UserName);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV12UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
         }
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Username = AV12UserName;
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Email = AV6Email;
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Firstname = AV8FirstName;
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Lastname = AV9LastName;
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Password = AV10Password;
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Confirmpassword = AV5ConfirmPassword;
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV18GXM1GAMSDRegisterUser_Level_DetailSdt = new SdtGAMSDRegisterUser_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         Gxdynprop = "";
         AV12UserName = "";
         AV6Email = "";
         AV8FirstName = "";
         AV9LastName = "";
         AV10Password = "";
         AV5ConfirmPassword = "";
         /* GeneXus formulas. */
      }

      private int AV14gxid ;
      private string Gxids ;
      private string AV8FirstName ;
      private string AV9LastName ;
      private string AV10Password ;
      private string AV5ConfirmPassword ;
      private string Gxdynprop ;
      private string AV12UserName ;
      private string AV6Email ;
      private SdtGAMSDRegisterUser_Level_DetailSdt aP1_GXM1GAMSDRegisterUser_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV13GAMRepository ;
      private SdtGAMSDRegisterUser_Level_DetailSdt AV18GXM1GAMSDRegisterUser_Level_DetailSdt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gamsdregisteruser_level_detail_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gamsdregisteruser_level_detail_services : GxRestService
   {
      [OperationContract(Name = "GAMSDRegisterUser_Level_Detail" )]
      [WebInvoke(Method =  "GET" ,
      	BodyStyle =  WebMessageBodyStyle.Bare  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/?gxid={gxid}")]
      public SdtGAMSDRegisterUser_Level_DetailSdt_RESTInterface execute( string gxid )
      {
         SdtGAMSDRegisterUser_Level_DetailSdt_RESTInterface GXM1GAMSDRegisterUser_Level_DetailSdt = new SdtGAMSDRegisterUser_Level_DetailSdt_RESTInterface();
         try
         {
            if ( ! ProcessHeaders("gamsdregisteruser_level_detail") )
            {
               return null ;
            }
            gamsdregisteruser_level_detail worker = new gamsdregisteruser_level_detail(context);
            worker.IsMain = RunAsMain ;
            int gxrgxid = 0;
            gxrgxid = (int)(Math.Round(NumberUtil.Val( (string)(gxid), "."), 18, MidpointRounding.ToEven));
            SdtGAMSDRegisterUser_Level_DetailSdt gxrGXM1GAMSDRegisterUser_Level_DetailSdt = GXM1GAMSDRegisterUser_Level_DetailSdt.sdt;
            worker.execute(gxrgxid,out gxrGXM1GAMSDRegisterUser_Level_DetailSdt );
            worker.cleanup( );
            GXM1GAMSDRegisterUser_Level_DetailSdt = new SdtGAMSDRegisterUser_Level_DetailSdt_RESTInterface(gxrGXM1GAMSDRegisterUser_Level_DetailSdt) ;
            return GXM1GAMSDRegisterUser_Level_DetailSdt ;
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
