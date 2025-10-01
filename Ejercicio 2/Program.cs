//ejercicio_2
//Jose_David_moya

using System;
using System.Collections.Generic;


class Empleado // datos empleado
{
    public string Cedula;
    public string Nombre;
    public int Tipo;
    public float Horas;
    public float PrecioHora;

    public float SalarioOrdinario;
    public float Aumento;
    public float SalarioBruto;
    public float Deduccion;
    public float SalarioNeto;

    public void CalcularSalario() //formula salario
    {
        SalarioOrdinario = Horas * PrecioHora;

        if (Tipo == 1)
            Aumento = SalarioOrdinario * 0.15f;
        else if (Tipo == 2)
            Aumento = SalarioOrdinario * 0.10f;
        else if (Tipo == 3)
            Aumento = SalarioOrdinario * 0.05f;
        else
            Aumento = 0;

        SalarioBruto = SalarioOrdinario + Aumento;
        Deduccion = SalarioBruto * 0.0917f;
        SalarioNeto = SalarioBruto - Deduccion;
    }

    public void MostrarDatos() //mostrar en pantalla
    {
        Console.WriteLine("\n--- Resultado ---");
        Console.WriteLine($"Cédula: {Cedula}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Horas: {Horas}");
        Console.WriteLine($"Precio por Hora: {PrecioHora}");
        Console.WriteLine($"Salario Ordinario: {SalarioOrdinario}");
        Console.WriteLine($"Aumento: {Aumento}");
        Console.WriteLine($"Salario Bruto: {SalarioBruto}");
        Console.WriteLine($"Deducción: {Deduccion}");
        Console.WriteLine($"Salario Neto: {SalarioNeto}");
    }
}

class Estadisticas //ajuste salarios
{
    public int Cantidad = 0;
    public float Acumulado = 0;

    public void Agregar(float salarioNeto)
    {
        Cantidad++;
        Acumulado += salarioNeto;
    }

    public float Promedio()
    {
        if (Cantidad > 0)
            return Acumulado / Cantidad;
        else
            return 0;
    }

    public void Mostrar(string tipo)
    {
        Console.WriteLine($"\n--- Estadísticas {tipo} ---");
        Console.WriteLine($"Cantidad: {Cantidad}");
        Console.WriteLine($"Acumulado: {Acumulado}");
        Console.WriteLine($"Promedio: {Promedio()}");
    }
}

class Program //main()
{
    static void Main(string[] args)
    {
        Estadisticas operarios = new Estadisticas();
        Estadisticas tecnicos = new Estadisticas();
        Estadisticas profesionales = new Estadisticas();

        string continuar;

        do
        {
            Empleado emp = new Empleado();

            Console.WriteLine("Digite la cédula:");
            emp.Cedula = Console.ReadLine();

            Console.WriteLine("Digite el nombre:");
            emp.Nombre = Console.ReadLine();

            Console.WriteLine("Digite el tipo (1-Operario, 2-Técnico, 3-Profesional):");
            emp.Tipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite las horas:");
            emp.Horas = float.Parse(Console.ReadLine());

            Console.WriteLine("Digite el precio por hora:");
            emp.PrecioHora = float.Parse(Console.ReadLine());

            emp.CalcularSalario();
            emp.MostrarDatos();

            if (emp.Tipo == 1)
                operarios.Agregar(emp.SalarioNeto);
            else if (emp.Tipo == 2)
                tecnicos.Agregar(emp.SalarioNeto);
            else if (emp.Tipo == 3)
                profesionales.Agregar(emp.SalarioNeto);

            Console.WriteLine("\n¿Desea registrar otro empleado? (s/n)");
            continuar = Console.ReadLine().ToLower();

        } while (continuar == "s");

        // Mostrar estadisticas
        operarios.Mostrar("Operarios");
        tecnicos.Mostrar("Técnicos");
        profesionales.Mostrar("Profesionales");
    }
}
