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
   public class gamsdchangepassword_level_detail : GXProcedure
   {
      public gamsdchangepassword_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdchangepassword_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDChangePassword_Level_DetailSdt aP1_GXM4GAMSDChangePassword_Level_DetailSdt )
      {
         this.AV16gxid = aP0_gxid;
         this.AV23GXM4GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP1_GXM4GAMSDChangePassword_Level_DetailSdt=this.AV23GXM4GAMSDChangePassword_Level_DetailSdt;
      }

      public SdtGAMSDChangePassword_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM4GAMSDChangePassword_Level_DetailSdt);
         return AV23GXM4GAMSDChangePassword_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDChangePassword_Level_DetailSdt aP1_GXM4GAMSDChangePassword_Level_DetailSdt )
      {
         gamsdchangepassword_level_detail objgamsdchangepassword_level_detail;
         objgamsdchangepassword_level_detail = new gamsdchangepassword_level_detail();
         objgamsdchangepassword_level_detail.AV16gxid = aP0_gxid;
         objgamsdchangepassword_level_detail.AV23GXM4GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt(context) ;
         objgamsdchangepassword_level_detail.context.SetSubmitInitialConfig(context);
         objgamsdchangepassword_level_detail.initialize();
         Submit( executePrivateCatch,objgamsdchangepassword_level_detail);
         aP1_GXM4GAMSDChangePassword_Level_DetailSdt=this.AV23GXM4GAMSDChangePassword_Level_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamsdchangepassword_level_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV16gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Useridentification, "name") == 0 )
            {
               Gxdynprop1 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"name");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Useridentification, "email") == 0 )
            {
               Gxdynprop2 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"email");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
            }
            else if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Useridentification, "namema") == 0 )
            {
               Gxdynprop3 = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"namema");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Username\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop3) + "\"]";
            }
            AV14isPasswordExpires = false;
            AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusertochangepassword();
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10GAMUser.gxTpr_Name)) )
            {
               AV14isPasswordExpires = true;
               AV5UserName = AV10GAMUser.gxTpr_Name;
            }
            else
            {
               AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10GAMUser.gxTpr_Name)) )
               {
                  AV5UserName = AV10GAMUser.gxTpr_Name;
               }
               else
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            Gxwebsession.Set(Gxids+"gxvar_Username", AV5UserName);
            Gxwebsession.Set(Gxids+"gxvar_Ispasswordexpires", StringUtil.BoolToStr( AV14isPasswordExpires));
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV5UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
            AV14isPasswordExpires = BooleanUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Ispasswordexpires"));
         }
         AV23GXM4GAMSDChangePassword_Level_DetailSdt.gxTpr_Username = AV5UserName;
         AV23GXM4GAMSDChangePassword_Level_DetailSdt.gxTpr_Userpassword = AV6UserPassword;
         AV23GXM4GAMSDChangePassword_Level_DetailSdt.gxTpr_Userpasswordnew = AV7UserPasswordNew;
         AV23GXM4GAMSDChangePassword_Level_DetailSdt.gxTpr_Userpasswordnewconf = AV8UserPasswordNewConf;
         AV23GXM4GAMSDChangePassword_Level_DetailSdt.gxTpr_Ispasswordexpires = AV14isPasswordExpires;
         AV23GXM4GAMSDChangePassword_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV23GXM4GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         Gxdynprop1 = "";
         Gxdynprop = "";
         Gxdynprop2 = "";
         Gxdynprop3 = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV5UserName = "";
         AV6UserPassword = "";
         AV7UserPasswordNew = "";
         AV8UserPasswordNewConf = "";
         /* GeneXus formulas. */
      }

      private int AV16gxid ;
      private string Gxids ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private string Gxdynprop3 ;
      private string AV6UserPassword ;
      private string AV7UserPasswordNew ;
      private string AV8UserPasswordNewConf ;
      private bool AV14isPasswordExpires ;
      private string Gxdynprop ;
      private string AV5UserName ;
      private SdtGAMSDChangePassword_Level_DetailSdt aP1_GXM4GAMSDChangePassword_Level_DetailSdt ;
      private IGxSession Gxwebsession ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private SdtGAMSDChangePassword_Level_DetailSdt AV23GXM4GAMSDChangePassword_Level_DetailSdt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gamsdchangepassword_level_detail_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gamsdchangepassword_level_detail_services : GxRestService
   {
      [OperationContract(Name = "GAMSDChangePassword_Level_Detail" )]
      [WebInvoke(Method =  "GET" ,
      	BodyStyle =  WebMessageBodyStyle.Bare  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/?gxid={gxid}")]
      public SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface execute( string gxid )
      {
         SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface GXM4GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface();
         try
         {
            if ( ! ProcessHeaders("gamsdchangepassword_level_detail") )
            {
               return null ;
            }
            gamsdchangepassword_level_detail worker = new gamsdchangepassword_level_detail(context);
            worker.IsMain = RunAsMain ;
            int gxrgxid = 0;
            gxrgxid = (int)(Math.Round(NumberUtil.Val( (string)(gxid), "."), 18, MidpointRounding.ToEven));
            SdtGAMSDChangePassword_Level_DetailSdt gxrGXM4GAMSDChangePassword_Level_DetailSdt = GXM4GAMSDChangePassword_Level_DetailSdt.sdt;
            worker.execute(gxrgxid,out gxrGXM4GAMSDChangePassword_Level_DetailSdt );
            worker.cleanup( );
            GXM4GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface(gxrGXM4GAMSDChangePassword_Level_DetailSdt) ;
            return GXM4GAMSDChangePassword_Level_DetailSdt ;
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
