using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Modelisateur.Model
{
    //public class ElementDonneeConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type typeToConvert)
    //    {
    //        return typeToConvert == typeof(ElementDonnee);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        ElementDonnee elementDonnee = serializer.Deserialize<ElementDonnee>(reader);

    //        return elementDonnee;
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        ElementDonnee elementDonnee = value as ElementDonnee;

    //        Liaison liaison = new Liaison();
    //        liaison.NameEntite = elementDonnee.Name;
    //        liaison.NameElementDonnee = elementDonnee.Name;

    //        writer.WritePropertyName(nameof(elementDonnee.Name));
    //        writer.WriteValue(elementDonnee.Name);
    //        writer.WritePropertyName(nameof(elementDonnee.Type));
    //        writer.WriteValue(elementDonnee.Type);
    //        writer.WritePropertyName(nameof(elementDonnee.IsKey));
    //        writer.WriteValue(elementDonnee.IsKey);

    //        serializer.Serialize(writer, liaison);
    //    }
    //}

    //[JsonConverter(typeof(ElementDonneeConverter))]
    public class ElementDonnee : DomainEntityBase
    {
        public string Type { get; set; }
        public bool IsKey { get; set; }
        public bool Required { get; set; }
        //public Entite Entite { get; set; }
        //TODO: Create a base class Duplicatable with a generic Duplicate method
        public ElementDonnee Duplicate()
        {
            var newItem = new ElementDonnee();
            newItem.Name = this.Name;
            newItem.Type = this.Type;
            newItem.IsKey = this.IsKey;

            return newItem;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}