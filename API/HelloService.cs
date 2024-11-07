namespace WebApplication1;

using OneOf;

/// <summary>
/// Serviço de Hello.
/// </summary>
public class HelloService
{
    /// <summary>
    /// Retorna uma saudação ao mundo.
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public OneOf<string, Err> HelloWorld(int num)
    {
        if (num == 0)
        {
            return new Err("Número não pode ser 0", 400);
        }

        return $"Hello World {num}";
    }
}