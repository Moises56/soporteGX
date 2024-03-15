/*
				   File: type_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem
			Description: K2BMultiLevelMenuCollection
				 Author: Nemo 🐠 for C# version 18.0.5.175581
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="K2BMultiLevelMenuCollectionItem")]
	[XmlType(TypeName="K2BMultiLevelMenuCollectionItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem : GxUserType
	{
		public SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem( )
		{
			/* Constructor for serialization */
		}

		public SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu != null)
			{
				AddObjectProperty("K2BMultiLevelMenu", gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="K2BMultiLevelMenu" )]
		[XmlArray(ElementName="K2BMultiLevelMenu"  )]
		[XmlArrayItemAttribute(ElementName="K2BMultiLevelMenuItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> gxTpr_K2bmultilevelmenu_GXBaseCollection
		{
			get {
				if ( gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu == null )
				{
					gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenu", "");
				}
				return gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu;
			}
			set {
				gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_N = false;
				gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> gxTpr_K2bmultilevelmenu
		{
			get {
				if ( gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu == null )
				{
					gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenu", "");
				}
				gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_N = false;
				return gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu ;
			}
			set {
				gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_N = false;
				gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu = value;
				SetDirty("K2bmultilevelmenu");
			}
		}

		public void gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_SetNull()
		{
			gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_N = true;
			gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu = null;
		}

		public bool gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_IsNull()
		{
			return gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu == null;
		}
		public bool ShouldSerializegxTpr_K2bmultilevelmenu_GXBaseCollection_Json()
		{
			return gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu != null && gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_K2bmultilevelmenu_GXBaseCollection_Json()||  
				false);
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> gxTv_SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_K2bmultilevelmenu = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BMultiLevelMenuCollectionItem", Namespace="test")]
	public class SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_RESTInterface : GxGenericCollectionItem<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem_RESTInterface( SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="K2BMultiLevelMenu", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface> gxTpr_K2bmultilevelmenu
		{
			get { 
				if (sdt.ShouldSerializegxTpr_K2bmultilevelmenu_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface>(sdt.gxTpr_K2bmultilevelmenu);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_K2bmultilevelmenu);
			}
		}


		#endregion

		public SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem sdt
		{
			get { 
				return (SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem() ;
			}
		}
	}
	#endregion
}