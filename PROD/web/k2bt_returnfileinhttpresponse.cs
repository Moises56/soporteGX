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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bt_returnfileinhttpresponse : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Guid");
            if ( ! entryPointCalled )
            {
               AV15Guid = StringUtil.StrToGuid( gxfirstwebparm);
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public k2bt_returnfileinhttpresponse( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bt_returnfileinhttpresponse( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_Guid )
      {
         this.AV15Guid = aP0_Guid;
         initialize();
         executePrivate();
      }

      public void executeSubmit( Guid aP0_Guid )
      {
         k2bt_returnfileinhttpresponse objk2bt_returnfileinhttpresponse;
         objk2bt_returnfileinhttpresponse = new k2bt_returnfileinhttpresponse();
         objk2bt_returnfileinhttpresponse.AV15Guid = aP0_Guid;
         objk2bt_returnfileinhttpresponse.context.SetSubmitInitialConfig(context);
         objk2bt_returnfileinhttpresponse.initialize();
         Submit( executePrivateCatch,objk2bt_returnfileinhttpresponse);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bt_returnfileinhttpresponse)stateInfo).executePrivate();
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
         GXt_char1 = AV11FileName;
         new k2bsessionget(context ).execute(  AV15Guid.ToString(), out  GXt_char1) ;
         AV11FileName = GXt_char1;
         new k2bsessionremove(context ).execute(  AV15Guid.ToString()) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11FileName)) )
         {
            /* Execute user subroutine: 'NOTAUTHORIZED' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            context.nUserReturn = 1;
            if ( context.WillRedirect( ) )
            {
               context.Redirect( context.wjLoc );
               context.wjLoc = "";
            }
            this.cleanup();
            if (true) return;
         }
         AV10file.Source = AV11FileName;
         if ( ! AV10file.Exists() )
         {
            /* Execute user subroutine: 'NOTAUTHORIZED' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            context.nUserReturn = 1;
            if ( context.WillRedirect( ) )
            {
               context.Redirect( context.wjLoc );
               context.wjLoc = "";
            }
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'GETCONTENTTYPE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV8HttpResponse.AppendHeader("Content-Type", AV14ContentType);
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV8HttpResponse.AppendHeader("Content-Disposition", StringUtil.Format( "attachment;filename=%1", AV10file.GetName(), "", "", "", "", "", "", "", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV8HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV8HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV8HttpResponse.AddFile(AV11FileName);
         new k2bremoveexceldocument(context).executeSubmit(  AV11FileName) ;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'GETCONTENTTYPE' Routine */
         returnInSub = false;
         AV12extension = AV10file.GetName();
         AV13lastDotPosition = (short)(StringUtil.StringSearch( AV12extension, ".", 1));
         while ( AV13lastDotPosition > 0 )
         {
            AV12extension = StringUtil.Substring( AV12extension, AV13lastDotPosition+1, -1);
            AV13lastDotPosition = (short)(StringUtil.StringSearch( AV12extension, ".", 1));
         }
         AV12extension = StringUtil.Lower( AV12extension);
         if ( StringUtil.StrCmp(AV12extension, "csv") == 0 )
         {
            AV14ContentType = "text/csv";
         }
         else if ( StringUtil.StrCmp(AV12extension, "xls") == 0 )
         {
            AV14ContentType = "application/vnd.ms-excel";
         }
         else if ( StringUtil.StrCmp(AV12extension, "xlsx") == 0 )
         {
            AV14ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
         }
         else if ( StringUtil.StrCmp(AV12extension, "pdf") == 0 )
         {
            AV14ContentType = "application/pdf";
         }
      }

      protected void S121( )
      {
         /* 'NOTAUTHORIZED' Routine */
         returnInSub = false;
         if ( ! context.isAjaxRequest( ) )
         {
            AV8HttpResponse.AppendHeader("Content-Type", "text/html");
         }
         AV8HttpResponse.AddString("<html><body><h1>There was an error returning the requested file.</h1></body></html>");
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV11FileName = "";
         GXt_char1 = "";
         AV10file = new GxFile(context.GetPhysicalPath());
         AV8HttpResponse = new GxHttpResponse( context);
         AV14ContentType = "";
         AV12extension = "";
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13lastDotPosition ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private string AV11FileName ;
      private string AV14ContentType ;
      private string AV12extension ;
      private Guid AV15Guid ;
      private GxHttpResponse AV8HttpResponse ;
      private GxFile AV10file ;
   }

}
