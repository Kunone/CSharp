public static T DeserializeTo<T>(this string textMsg)
{
    if (string.IsNullOrEmpty(textMsg) == null)
        throw new InvalidOperationException("Cannot parse received message, not a TextMessage");

    T result;
    var ser = new XmlSerializer(typeof(T));
    using (var xmlBodyReader = new StringReader(textMsg))
    {
        try
        {
            result = (T)ser.Deserialize(xmlBodyReader);
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException("Error deserializing process message: " + ex.Message, ex);
        }
    }
    return result;
}
