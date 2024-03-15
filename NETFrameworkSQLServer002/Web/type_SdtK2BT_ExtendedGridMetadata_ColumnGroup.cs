/*
				   File: type_SdtK2BT_ExtendedGridMetadata_ColumnGroup
			Description: ColumnGroups
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
	[XmlRoot(ElementName="K2BT_ExtendedGridMetadata.ColumnGroup")]
	[XmlType(TypeName="K2BT_ExtendedGridMetadata.ColumnGroup" , Namespace="test" )]
	[Serializable]
	public class SdtK2BT_ExtendedGridMetadata_ColumnGroup : GxUserType
	{
		public SdtK2BT_ExtendedGridMetadata_ColumnGroup( )
		{
			/* Constructor for serialization */
		}

		public SdtK2BT_ExtendedGridMetadata_ColumnGroup(IGxContext context)
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
			if (gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames != null)
			{
				AddObjectProperty("MemberColumnNames", gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames, false);
			}

			AddObjectProperty("CanBeMoved", gxTpr_Canbemoved, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MemberColumnNames" )]
		[XmlArray(ElementName="MemberColumnNames"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Membercolumnnames_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Membercolumnnames
		{
			get {
				if ( gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames == null )
				{
					gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames = new GxSimpleCollection<string>();
				}
				gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_N = false;
				return gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames ;
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_N = false;
				gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames = value;
				SetDirty("Membercolumnnames");
			}
		}

		public void gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_SetNull()
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_N = true;
			gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames = null;
		}

		public bool gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_IsNull()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames == null;
		}
		public bool ShouldSerializegxTpr_Membercolumnnames_GxSimpleCollection_Json()
		{
			return gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames != null && gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames.Count > 0;

		}


		[SoapElement(ElementName="CanBeMoved")]
		[XmlElement(ElementName="CanBeMoved")]
		public bool gxTpr_Canbemoved
		{
			get {
				return gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Canbemoved; 
			}
			set {
				gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Canbemoved = value;
				SetDirty("Canbemoved");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_N = true;


			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames_N;
		protected GxSimpleCollection<string> gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Membercolumnnames = null;  

		protected bool gxTv_SdtK2BT_ExtendedGridMetadata_ColumnGroup_Canbemoved;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BT_ExtendedGridMetadata.ColumnGroup", Namespace="test")]
	public class SdtK2BT_ExtendedGridMetadata_ColumnGroup_RESTInterface : GxGenericCollectionItem<SdtK2BT_ExtendedGridMetadata_ColumnGroup>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BT_ExtendedGridMetadata_ColumnGroup_RESTInterface( ) : base()
		{	
		}

		public SdtK2BT_ExtendedGridMetadata_ColumnGroup_RESTInterface( SdtK2BT_ExtendedGridMetadata_ColumnGroup psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MemberColumnNames", Order=0, EmitDefaultValue=false)]
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

		[DataMember(Name="CanBeMoved", Order=1)]
		public bool gxTpr_Canbemoved
		{
			get { 
				return sdt.gxTpr_Canbemoved;

			}
			set { 
				sdt.gxTpr_Canbemoved = value;
			}
		}


		#endregion

		public SdtK2BT_ExtendedGridMetadata_ColumnGroup sdt
		{
			get { 
				return (SdtK2BT_ExtendedGridMetadata_ColumnGroup)Sdt;
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
				sdt = new SdtK2BT_ExtendedGridMetadata_ColumnGroup() ;
			}
		}
	}
	#endregion
}