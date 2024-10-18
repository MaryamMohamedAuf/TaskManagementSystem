namespace TaskManagementSystem.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendTaskMessage<T>(T message);

    }
}
