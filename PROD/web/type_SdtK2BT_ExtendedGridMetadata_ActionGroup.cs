/*
				   File: type_SdtK2BT_ExtendedGridMetadata_ActionGroup
			Description: ActionGroups
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
	[XmlRoot(ElementName="K2BT_ExtendedGridMetadata.ActionGroup")]
	[XmlType(TypeName="K2BT_ExtendedGridMetadata.ActionGroup" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_ExtendedGridMetadata_ActionGroup : GxUserType
	{
		public SdtK2BT_ExtendedGridMetadata_ActionGroup( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Caption = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Iconurl = "";

		}

		public SdtK2BT_ExtendedGridMetadata_ActionGroup(IGxContext context)
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
			AddObjectProperty("Caption", gxTpr_Caption, false);


			AddObjectProperty("IconURL", gxTpr_Iconurl, false);

			if (gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames != null)
			{
				AddObjectProperty("MemberColumnNames", gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Caption")]
		[XmlElement(ElementName="Caption")]
		public string gxTpr_Caption
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Caption; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Caption = value;
				SetDirty("Caption");
			}
		}




		[SoapElement(ElementName="IconURL")]
		[XmlElement(ElementName="IconURL")]
		public string gxTpr_Iconurl
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Iconurl; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Iconurl = value;
				SetDirty("Iconurl");
			}
		}




		[SoapElement(ElementName="MemberColumnNames" )]
		[XmlArray(ElementName="MemberColumnNames"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Membercolumnnames_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Membercolumnnames
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames = new GxSimpleCollection<string>();
				}
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_N = false;
				return gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames ;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames = value;
				SetDirty("Membercolumnnames");
			}
		}

		public void gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_SetNull()
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_N = true;
			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames = null;
		}

		public bool gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames == null;
		}
		public bool ShouldSerializegxTpr_Membercolumnnames_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames != null && gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Caption = "";
			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Iconurl = "";

			gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Caption;
		 

		protected string gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Iconurl;
		 
		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames_N;
		protected GxSimpleCollection<string> gxTv_SdtK2BT_ExtendedGridMetadata_ActionGroup_Membercolumnnames = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BT_ExtendedGridMetadata.ActionGroup", Namespace="test")]
	public class SdtK2BT_ExtendedGridMetadata_ActionGroup_RESTInterface : GxGenericCollectionItem<SdtK2BT_ExtendedGridMetadata_ActionGroup>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_ExtendedGridMetadata_ActionGroup_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_ExtendedGridMetadata_ActionGroup_RESTInterface( SdtK2BT_ExtendedGridMetadata_ActionGroup psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Caption", Order=0)]
		public  string gxTpr_Caption
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Caption);

			}
			set { 
				 sdt.gxTpr_Caption = value;
			}
		}

		[DataMember(Name="IconURL", Order=1)]
		public  string gxTpr_Iconurl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Iconurl);

			}
			set { 
				 sdt.gxTpr_Iconurl = value;
			}
		}

		[DataMember(Name="MemberColumnNames", Order=2, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Membercolumnnames
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Membercolumnnames_GxSimpleCollection_Json())
					return sdt.gxTpr_Membercolumnnames;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Membercolumnnames = value ;
			}
		}


		#endregion

		public SdtK2BT_ExtendedGridMetadata_ActionGroup sdt
		{
			get { 
				return (SdtK2BT_ExtendedGridMetadata_ActionGroup)Sdt;
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
				sdt = new SdtK2BT_ExtendedGridMetadata_ActionGroup() ;
			}
		}
	}
	#endregion
}