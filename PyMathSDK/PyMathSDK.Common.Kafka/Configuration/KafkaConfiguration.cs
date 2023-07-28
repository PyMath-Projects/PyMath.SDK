namespace PyMathSDK.Common.Kafka.Configuration;

public record KafkaConfiguration : IKafkaConfiguration
{
    public string BootstrapServers { get; set; }

    public int ProducerFlushTimeOutSeconds { get; set; }

    public ProducerConfiguration ProducerConfiguration { get; set; }
}