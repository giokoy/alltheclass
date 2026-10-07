using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];

        switch (reading)
        {
            case >= 4_294_967_296L and <= 9_223_372_036_854_775_807L:
                buffer[0] = 256 - 8; // long (signed)
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                break;

            case >= 2_147_483_648L and <= 4_294_967_295L:
                buffer[0] = 4; // uint (unsigned)
                BitConverter.GetBytes((uint)reading).CopyTo(buffer, 1);
                break;

            case >= 65_536L and <= 2_147_483_647L:
                buffer[0] = 256 - 4; // int (signed)
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                break;

            case >= 0L and <= 65_535L:
                buffer[0] = 2; // ushort (unsigned)
                BitConverter.GetBytes((ushort)reading).CopyTo(buffer, 1);
                break;

            case >= -32_768L and <= -1L:
                buffer[0] = 256 - 2; // short (signed)
                BitConverter.GetBytes((short)reading).CopyTo(buffer, 1);
                break;

            case >= -2_147_483_648L and <= -32_769L:
                buffer[0] = 256 - 4; // int (signed)
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                break;

            default:
                buffer[0] = 256 - 8; // long (signed: -9_223_372_036_854_775_808 a -2_147_483_649)
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                break;
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return buffer[0] switch
        {
            256 - 8 => BitConverter.ToInt64(buffer, 1),
            4       => BitConverter.ToUInt32(buffer, 1),
            256 - 4 => BitConverter.ToInt32(buffer, 1),
            2       => BitConverter.ToUInt16(buffer, 1),
            256 - 2 => BitConverter.ToInt16(buffer, 1),
            _       => 0L
        };
    }
}

class TelemetryProgram
{
    static void Main(string[] args)
    {
        long[] testValues = {
            5,                              // ushort (2 bytes, unsigned)
            -500,                           // short (2 bytes, signed)
            100_000,                        // int (4 bytes, signed)
            3_000_000_000L,                 // uint (4 bytes, unsigned)
            10_000_000_000L,                // long (8 bytes, signed positivo)
            -3_000_000_000L                 // long (8 bytes, signed negativo)
        };

        Console.WriteLine($"{"Valor original",-18} {"Prefijo",-10} {"Bytes (hex)",-30} {"Decodificado",-15}");
        Console.WriteLine(new string('-', 75));

        foreach (long value in testValues)
        {
            // 1. Codificar a buffer
            byte[] buffer = TelemetryBuffer.ToBuffer(value);

            // 2. Decodificar desde buffer
            long decoded = TelemetryBuffer.FromBuffer(buffer);

            // Formatear salida en consola
            string hexBytes = BitConverter.ToString(buffer);
            Console.WriteLine($"{value,-18} {buffer[0],-10} {hexBytes,-30} {decoded,-15}");
        }

        // Caso inválido: buffer con prefijo no reconocido
        byte[] invalidBuffer = new byte[9];
        invalidBuffer[0] = 255;
        Console.WriteLine($"\nBuffer inválido (prefijo 255) -> Decodificado: {TelemetryBuffer.FromBuffer(invalidBuffer)}");
    }
}