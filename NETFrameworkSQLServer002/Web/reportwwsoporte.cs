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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class reportwwsoporte : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "hostName_Filter");
            if ( ! entryPointCalled )
            {
               AV15hostName_Filter = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV10OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public reportwwsoporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public reportwwsoporte( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_hostName_Filter ,
                           string aP1_K2BToolsGenericSearchField ,
                           short aP2_OrderedBy )
      {
         this.AV15hostName_Filter = aP0_hostName_Filter;
         this.AV9K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         this.AV10OrderedBy = aP2_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_hostName_Filter ,
                                 string aP1_K2BToolsGenericSearchField ,
                                 short aP2_OrderedBy )
      {
         reportwwsoporte objreportwwsoporte;
         objreportwwsoporte = new reportwwsoporte();
         objreportwwsoporte.AV15hostName_Filter = aP0_hostName_Filter;
         objreportwwsoporte.AV9K2BToolsGenericSearchField = aP1_K2BToolsGenericSearchField;
         objreportwwsoporte.AV10OrderedBy = aP2_OrderedBy;
         objreportwwsoporte.context.SetSubmitInitialConfig(context);
         objreportwwsoporte.initialize();
         Submit( executePrivateCatch,objreportwwsoporte);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwsoporte)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ReportWWsoporte_rpt");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new k2bgetcontext(context ).execute( out  AV8Context) ;
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "soporte",  "soporte",  "List",  "",  AV22Pgmname) )
            {
               H3B0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "K2BT_NotAuthorizedToViewReport", ""), 63, Gx_line+0, 764, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H3B0( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "SOPORTE", ""), 336, Gx_line+0, 490, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
               {
                  H3B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "K2BT_GenericFilterReportLabel", ""), 10, Gx_line+7, 55, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15hostName_Filter)) )
               {
                  H3B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Name", ""), 10, Gx_line+7, 40, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15hostName_Filter, "")), 48, Gx_line+7, 341, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H3B0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "ID", ""), 18, Gx_line+7, 85, Gx_line+22, 2, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "HostName", ""), 93, Gx_line+7, 182, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Serie", ""), 190, Gx_line+7, 279, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "IPV4", ""), 287, Gx_line+7, 376, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "MAC", ""), 384, Gx_line+7, 483, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Modelo", ""), 491, Gx_line+7, 590, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "NombreUsuario", ""), 598, Gx_line+7, 697, Gx_line+22, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 705, Gx_line+7, 804, Gx_line+22, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV15hostName_Filter ,
                                                    AV9K2BToolsGenericSearchField ,
                                                    A5hostName ,
                                                    A4soporteID ,
                                                    A10ipv4 ,
                                                    A11mac ,
                                                    A12modelo ,
                                                    A13nombreUsuario ,
                                                    A14nombreDepartamento ,
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.SHORT
                                                    }
               });
               lV15hostName_Filter = StringUtil.Concat( StringUtil.RTrim( AV15hostName_Filter), "%", "");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
               /* Using cursor P003B2 */
               pr_default.execute(0, new Object[] {lV15hostName_Filter, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A14nombreDepartamento = P003B2_A14nombreDepartamento[0];
                  A13nombreUsuario = P003B2_A13nombreUsuario[0];
                  A12modelo = P003B2_A12modelo[0];
                  A11mac = P003B2_A11mac[0];
                  A10ipv4 = P003B2_A10ipv4[0];
                  A9serie = P003B2_A9serie[0];
                  A4soporteID = P003B2_A4soporteID[0];
                  A5hostName = P003B2_A5hostName[0];
                  H3B0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A4soporteID), "ZZZZZZZZ9")), 18, Gx_line+7, 85, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5hostName, "")), 93, Gx_line+7, 182, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A9serie, "")), 190, Gx_line+7, 279, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10ipv4, "")), 287, Gx_line+7, 376, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A11mac, "")), 384, Gx_line+7, 483, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A12modelo, "")), 491, Gx_line+7, 590, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13nombreUsuario, "")), 598, Gx_line+7, 697, Gx_line+23, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14nombreDepartamento, "")), 705, Gx_line+7, 804, Gx_line+23, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3B0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H3B0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxDrawLine(50, Gx_line+0, 775, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 383, Gx_line+33, 398, Gx_line+47, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "{{Pages}}", ""), 417, Gx_line+33, 432, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Page", ""), 353, Gx_line+33, 383, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "of", ""), 400, Gx_line+33, 415, Gx_line+47, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "b7ea4f08-f7a5-4fad-b32e-2c1b1255fdbb", "", context.GetTheme( )), 0, Gx_line+0, 75, Gx_line+67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 608, Gx_line+0, 653, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Date", ""), 575, Gx_line+0, 608, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Page", ""), 720, Gx_line+0, 750, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "of", ""), 767, Gx_line+0, 782, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "{{Pages}}", ""), 783, Gx_line+0, 798, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 750, Gx_line+0, 765, Gx_line+14, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+71);
               if ( GxHdr3 )
               {
                  getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "ID", ""), 18, Gx_line+7, 85, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "HostName", ""), 93, Gx_line+7, 182, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "Serie", ""), 190, Gx_line+7, 279, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "IPV4", ""), 287, Gx_line+7, 376, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "MAC", ""), 384, Gx_line+7, 483, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "Modelo", ""), 491, Gx_line+7, 590, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "NombreUsuario", ""), 598, Gx_line+7, 697, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 705, Gx_line+7, 804, Gx_line+22, 0, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Courier New", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Courier New", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         AV8Context = new SdtK2BContext(context);
         AV22Pgmname = "";
         scmdbuf = "";
         lV15hostName_Filter = "";
         lV9K2BToolsGenericSearchField = "";
         A5hostName = "";
         A10ipv4 = "";
         A11mac = "";
         A12modelo = "";
         A13nombreUsuario = "";
         A14nombreDepartamento = "";
         P003B2_A14nombreDepartamento = new string[] {""} ;
         P003B2_A13nombreUsuario = new string[] {""} ;
         P003B2_A12modelo = new string[] {""} ;
         P003B2_A11mac = new string[] {""} ;
         P003B2_A10ipv4 = new string[] {""} ;
         P003B2_A9serie = new string[] {""} ;
         P003B2_A4soporteID = new int[1] ;
         P003B2_A5hostName = new string[] {""} ;
         A9serie = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportwwsoporte__default(),
            new Object[][] {
                new Object[] {
               P003B2_A14nombreDepartamento, P003B2_A13nombreUsuario, P003B2_A12modelo, P003B2_A11mac, P003B2_A10ipv4, P003B2_A9serie, P003B2_A4soporteID, P003B2_A5hostName
               }
            }
         );
         AV22Pgmname = "ReportWWsoporte";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV22Pgmname = "ReportWWsoporte";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A4soporteID ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV22Pgmname ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool GxHdr3 ;
      private string AV15hostName_Filter ;
      private string lV15hostName_Filter ;
      private string A5hostName ;
      private string A10ipv4 ;
      private string A11mac ;
      private string A12modelo ;
      private string A13nombreUsuario ;
      private string A14nombreDepartamento ;
      private string A9serie ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003B2_A14nombreDepartamento ;
      private string[] P003B2_A13nombreUsuario ;
      private string[] P003B2_A12modelo ;
      private string[] P003B2_A11mac ;
      private string[] P003B2_A10ipv4 ;
      private string[] P003B2_A9serie ;
      private int[] P003B2_A4soporteID ;
      private string[] P003B2_A5hostName ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwsoporte__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003B2( IGxContext context ,
                                             string AV15hostName_Filter ,
                                             string AV9K2BToolsGenericSearchField ,
                                             string A5hostName ,
                                             int A4soporteID ,
                                             string A10ipv4 ,
                                             string A11mac ,
                                             string A12modelo ,
                                             string A13nombreUsuario ,
                                             string A14nombreDepartamento ,
                                             short AV10OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [nombreDepartamento], [nombreUsuario], [modelo], [mac], [ipv4], [serie], [soporteID], [hostName] FROM [soporte]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15hostName_Filter)) )
         {
            AddWhere(sWhereString, "([hostName] like @lV15hostName_Filter)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(9), CAST([soporteID] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [hostName] like '%' + @lV9K2BToolsGenericSearchField + '%' or [serie] like '%' + @lV9K2BToolsGenericSearchField + '%' or [ipv4] like '%' + @lV9K2BToolsGenericSearchField + '%' or [mac] like '%' + @lV9K2BToolsGenericSearchField + '%' or [modelo] like '%' + @lV9K2BToolsGenericSearchField + '%' or [nombreUsuario] like '%' + @lV9K2BToolsGenericSearchField + '%' or [nombreDepartamento] like '%' + @lV9K2BToolsGenericSearchField + '%')");
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
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [soporteID]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [soporteID] DESC";
         }
         else if ( AV10OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [hostName]";
         }
         else if ( AV10OrderedBy == 3 )
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
                     return conditional_P003B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmP003B2;
          prmP003B2 = new Object[] {
          new ParDef("@lV15hostName_Filter",GXType.NVarChar,40,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B2,100, GxCacheFrequency.OFF ,false,false )
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
