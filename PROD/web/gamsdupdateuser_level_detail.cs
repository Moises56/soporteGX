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
   public class gamsdupdateuser_level_detail : GXProcedure
   {
      public gamsdupdateuser_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdupdateuser_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDUpdateUser_Level_DetailSdt aP1_GXM4GAMSDUpdateUser_Level_DetailSdt )
      {
         this.AV17gxid = aP0_gxid;
         this.AV24GXM4GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM4GAMSDUpdateUser_Level_DetailSdt=this.AV24GXM4GAMSDUpdateUser_Level_DetailSdt;
      }

      public SdtGAMSDUpdateUser_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM4GAMSDUpdateUser_Level_DetailSdt);
         return AV24GXM4GAMSDUpdateUser_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDUpdateUser_Level_DetailSdt aP1_GXM4GAMSDUpdateUser_Level_DetailSdt )
      {
         gamsdupdateuser_level_detail objgamsdupdateuser_level_detail;
         objgamsdupdateuser_level_detail = new gamsdupdateuser_level_detail();
         objgamsdupdateuser_level_detail.AV17gxid = aP0_gxid;
         objgamsdupdateuser_level_detail.AV24GXM4GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt(context) ;
         objgamsdupdateuser_level_detail.context.SetSubmitInitialConfig(context);
         objgamsdupdateuser_level_detail.initialize();
         Submit( executePrivateCatch,objgamsdupdateuser_level_detail);
         aP1_GXM4GAMSDUpdateUser_Level_DetailSdt=this.AV24GXM4GAMSDUpdateUser_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamsdupdateuser_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV17gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV16GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( StringUtil.StrCmp(AV16GAMRepository.gxTpr_Useridentification, "name") == 0 )
            {
               Gxdynprop1 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"name");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV16GAMRepository.gxTpr_Useridentification, "email") == 0 )
            {
               Gxdynprop2 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"email");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV16GAMRepository.gxTpr_Useridentification, "namema") == 0 )
            {
               Gxdynprop3 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"namema");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop3) + "\"]";
            }
            AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV7GAMErrorCollection);
            if ( AV7GAMErrorCollection.Count == 0 )
            {
               AV15UserGUID = AV13GAMUser.gxTpr_Guid;
               AV12UserName = AV13GAMUser.gxTpr_Name;
               AV6Email = AV13GAMUser.gxTpr_Email;
               AV8FirstName = AV13GAMUser.gxTpr_Firstname;
               AV9LastName = AV13GAMUser.gxTpr_Lastname;
            }
            Gxwebsession.Set(Gxids+"gxvar_Username", AV12UserName);
            Gxwebsession.Set(Gxids+"gxvar_Email", AV6Email);
            Gxwebsession.Set(Gxids+"gxvar_Firstname", AV8FirstName);
            Gxwebsession.Set(Gxids+"gxvar_Lastname", AV9LastName);
            Gxwebsession.Set(Gxids+"gxvar_Userguid", AV15UserGUID);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV12UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
            AV15UserGUID = Gxwebsession.Get(Gxids+"gxvar_Userguid");
            AV6Email = Gxwebsession.Get(Gxids+"gxvar_Email");
            AV8FirstName = Gxwebsession.Get(Gxids+"gxvar_Firstname");
            AV9LastName = Gxwebsession.Get(Gxids+"gxvar_Lastname");
         }
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt.gxTpr_Username = AV12UserName;
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt.gxTpr_Email = AV6Email;
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt.gxTpr_Firstname = AV8FirstName;
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt.gxTpr_Lastname = AV9LastName;
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt.gxTpr_Userguid = AV15UserGUID;
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV24GXM4GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV16GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         Gxdynprop1 = "";
         Gxdynprop = "";
         Gxdynprop2 = "";
         Gxdynprop3 = "";
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV7GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV15UserGUID = "";
         AV12UserName = "";
         AV6Email = "";
         AV8FirstName = "";
         AV9LastName = "";
         /* GeneXus formulas. */
      }

      private int AV17gxid ;
      private string Gxids ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private string Gxdynprop3 ;
      private string AV15UserGUID ;
      private string AV8FirstName ;
      private string AV9LastName ;
      private string Gxdynprop ;
      private string AV12UserName ;
      private string AV6Email ;
      private SdtGAMSDUpdateUser_Level_DetailSdt aP1_GXM4GAMSDUpdateUser_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV7GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV16GAMRepository ;
      private SdtGAMSDUpdateUser_Level_DetailSdt AV24GXM4GAMSDUpdateUser_Level_DetailSdt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gamsdupdateuser_level_detail_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gamsdupdateuser_level_detail_services : GxRestService
   {
      [OperationContract(Name = "GAMSDUpdateUser_Level_Detail" )]
      [WebInvoke(Method =  "GET" ,
      	BodyStyle =  WebMessageBodyStyle.Bare  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/?gxid={gxid}")]
      public SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface execute( string gxid )
      {
         SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface GXM4GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface();
         try
         {
            if ( ! ProcessHeaders("gamsdupdateuser_level_detail") )
            {
               return null ;
            }
            gamsdupdateuser_level_detail worker = new gamsdupdateuser_level_detail(context);
            worker.IsMain = RunAsMain ;
            int gxrgxid = 0;
            gxrgxid = (int)(Math.Round(NumberUtil.Val( (string)(gxid), "."), 18, MidpointRounding.ToEven));
            SdtGAMSDUpdateUser_Level_DetailSdt gxrGXM4GAMSDUpdateUser_Level_DetailSdt = GXM4GAMSDUpdateUser_Level_DetailSdt.sdt;
            worker.execute(gxrgxid,out gxrGXM4GAMSDUpdateUser_Level_DetailSdt );
            worker.cleanup( );
            GXM4GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface(gxrGXM4GAMSDUpdateUser_Level_DetailSdt) ;
            return GXM4GAMSDUpdateUser_Level_DetailSdt ;
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
