
using System;

namespace Models
{
    public class CommentResponse
    {
        public string text { get; set; }
        public Parent parent { get; set; }
        public Appliesto appliesTo { get; set; }
        public DateTime date { get; set; }
        public Id4 id { get; set; }
        public _Meta2 _meta { get; set; }
        public string[] tags { get; set; }
        public Rulesdata2 rulesData { get; set; }
        public Attributes2 attributes { get; set; }
        public Identifiers2 identifiers { get; set; }
    }

    public class Parent
    {
        public string commentId { get; set; }
        public string organizationId { get; set; }
    }

    public class Appliesto
    {
        public Condition[] conditions { get; set; }
        public Target[] targets { get; set; }
        public _Meta _meta { get; set; }
        public string[] tags { get; set; }
        public Rulesdata rulesData { get; set; }
        public Attributes attributes { get; set; }
        public Identifiers identifiers { get; set; }
    }

    public class _Meta
    {
        public int schema { get; set; }
        public Created created { get; set; }
        public Modified modified { get; set; }
        public Deleted deleted { get; set; }
        public Template template { get; set; }
        public int version { get; set; }
    }

    public class Created
    {
        public string comments { get; set; }
        public By by { get; set; }
        public System system { get; set; }
        public DateTime date { get; set; }
    }

    public class By
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Modified
    {
        public string comments { get; set; }
        public By1 by { get; set; }
        public System1 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By1
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System1
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Deleted
    {
        public string comments { get; set; }
        public By2 by { get; set; }
        public System2 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System2
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Template
    {
        public Id id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Id
    {
        public string templateId { get; set; }
    }

    public class Rulesdata
    {
    }

    public class Attributes
    {
    }

    public class Identifiers
    {
    }

    public class Condition
    {
        public string _operator { get; set; }
        public Left left { get; set; }
        public Right right { get; set; }
        public bool inverse { get; set; }
        public Condition1[] conditions { get; set; }
        public Id1 id { get; set; }
        public _Meta1 _meta { get; set; }
        public string[] tags { get; set; }
        public Rulesdata1 rulesData { get; set; }
        public Attributes1 attributes { get; set; }
        public Identifiers1 identifiers { get; set; }
    }

    public class Left
    {
        public Property1 property { get; set; }
        public Value value { get; set; }
    }

    public class Property1
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Value
    {
    }

    public class Right
    {
        public Property2 property { get; set; }
        public Value1 value { get; set; }
    }

    public class Property2
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Value1
    {
    }

    public class Id1
    {
        public string ruleId { get; set; }
        public string conditionId { get; set; }
    }

    public class _Meta1
    {
        public int schema { get; set; }
        public Created1 created { get; set; }
        public Modified1 modified { get; set; }
        public Deleted1 deleted { get; set; }
        public Template1 template { get; set; }
        public int version { get; set; }
    }

    public class Created1
    {
        public string comments { get; set; }
        public By3 by { get; set; }
        public System3 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By3
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System3
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Modified1
    {
        public string comments { get; set; }
        public By4 by { get; set; }
        public System4 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By4
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System4
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Deleted1
    {
        public string comments { get; set; }
        public By5 by { get; set; }
        public System5 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By5
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System5
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Template1
    {
        public Id2 id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Id2
    {
        public string templateId { get; set; }
    }

    public class Rulesdata1
    {
    }

    public class Attributes1
    {
    }

    public class Identifiers1
    {
    }

    public class Condition1
    {
    }

    public class Target
    {
        public Id3 id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Id3
    {
    }

    public class Id4
    {
        public string commentId { get; set; }
        public string organizationId { get; set; }
    }

    public class _Meta2
    {
        public int schema { get; set; }
        public Created2 created { get; set; }
        public Modified2 modified { get; set; }
        public Deleted2 deleted { get; set; }
        public Template2 template { get; set; }
        public int version { get; set; }
    }

    public class Created2
    {
        public string comments { get; set; }
        public By6 by { get; set; }
        public System6 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By6
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System6
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Modified2
    {
        public string comments { get; set; }
        public By7 by { get; set; }
        public System7 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By7
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System7
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Deleted2
    {
        public string comments { get; set; }
        public By8 by { get; set; }
        public System8 system { get; set; }
        public DateTime date { get; set; }
    }

    public class By8
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class System8
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Template2
    {
        public Id5 id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Id5
    {
        public string templateId { get; set; }
    }

    public class Rulesdata2
    {
    }

    public class Attributes2
    {
    }

    public class Identifiers2
    {
    }
}