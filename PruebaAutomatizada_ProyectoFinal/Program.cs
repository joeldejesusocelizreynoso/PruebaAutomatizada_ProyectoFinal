using System;
using System.IO;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;


public class Program
{
    static void Main()
    {
        IWebDriver driver_JDJOR = new ChromeDriver();
        // Nota importante: Antes de ejecutar la prueba automatizada siguiente, hay que asegurarse de ejecutar primero el proyecto local, de lo contrario no funcionará.
        driver_JDJOR.Navigate().GoToUrl("https://localhost:7000");
        driver_JDJOR.Manage().Window.Maximize();

        // En la siguiente dirección se guardarán las capturas de pantalla. Al momento de ejecutarlo en su ordenador (cualquier dispositivo) cambie esta ruta
        string screenshotDirectory = @"C:\Users\Laptop\source\repos\PruebaAutomatizada_ProyectoFinal\Capturas de Pantalla Automáticas";

        if (!Directory.Exists(screenshotDirectory))
        {
            Directory.CreateDirectory(screenshotDirectory);
        }

        int screenshotCounter = 1;

        try
        {
            
            /////////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para Verificar que el proyecto da la Bienvenida //
            /////////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement TituloBienvenida = driver_JDJOR.FindElement(By.Id("TituloBienvenida"));
            if (TituloBienvenida.Text.Contains("Bienvenido al Registro de Tardanzas"))
            {
                Console.WriteLine("Prueba exitosa: El mensaje de bienvenida está visible");
            }
            else
            {
                Console.WriteLine("Prueba fallida: El mensaje de bienvenida no está visible");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Verificando la Bienvenida de Inicio.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            ///////////////////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para visualizar el menú con sus opciones correspondientes //
            ///////////////////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();
            IWebElement MenuNavegacion = driver_JDJOR.FindElement(By.Id("MenuNavegacion"));
            IWebElement SeccionInicio = driver_JDJOR.FindElement(By.Id("SeccionInicio"));
            IWebElement SeccionRegistro = driver_JDJOR.FindElement(By.Id("SeccionRegistro"));
            IWebElement SeccionAcercaDe = driver_JDJOR.FindElement(By.Id("SeccionAcercaDe"));

            if (MenuNavegacion.Displayed && MenuNavegacion.Enabled && MenuNavegacion.Text.Contains("Inicio") && MenuNavegacion.Text.Contains("Registro") && MenuNavegacion.Text.Contains("Acerca De"))
            {
                Console.WriteLine("Prueba exitosa: El menú de navegación está visible con las opciones correctas.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: El menú de navegación no es visible o faltan opciones.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Visualizando el Menú con sus respectivas Opciones.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }
            
        try
        {
            //////////////////////////////////////////////////////////////
            // Prueba Automatizada para entrar a la sección de Registro //
            //////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement SeccionRegistro = driver_JDJOR.FindElement(By.Id("SeccionRegistro"));
            if (SeccionRegistro.Displayed && SeccionRegistro.Enabled)
            {
                Task.Delay(2000).Wait();
                SeccionRegistro.Click();
                Console.WriteLine("Prueba exitosa: Ha sido redirigido correctamente a la sección de Registro.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: No ha sido redirigido correctamente a la sección de Registro.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Entrar a la Sección de Registro.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }
        
        try
        {
            ////////////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para verificar que estoy en el Listado de Registro //
            ////////////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            string TituloListadoRegistro = driver_JDJOR.Title;
            if (TituloListadoRegistro == "Listado de Registros")
            {
                Console.WriteLine("Prueba exitosa: Se encuentra en la sección Listado de Registros.");
            }
            else
            {
                Console.WriteLine("Pruaba fallida: Algo ha salido mal o No se encuentra en la sección Listado de Registros.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Verificando que se está en la Página Listado de Registros.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            //////////////////////////////////////////////////////
            // Prueba Automatizada para crear un nuevo registro //
            //////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement NuevoRegistro = driver_JDJOR.FindElement(By.Id("NuevoRegistro"));
            if (NuevoRegistro.Displayed && NuevoRegistro.Enabled)
            {
                Task.Delay(2000).Wait();
                NuevoRegistro.Click();
                Console.WriteLine("Prueba exitosa: Ha sido redirigido a la edición de registros.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: No ha sido redirigido a la edición de registros");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Creando un nuevo Registro.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para verificar que los cuadros de texto son visibles y se pueden editar, y que también se pueda agregar información //
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement CuadroTextoMatricula = driver_JDJOR.FindElement(By.XPath("//*[@id=\"TextBoxMatricula\"]"));
            IWebElement CuadroTextoNombre = driver_JDJOR.FindElement(By.XPath("//*[@id=\"TextBoxNombre\"]"));
            IWebElement CuadroTextoApellido = driver_JDJOR.FindElement(By.XPath("//*[@id=\"TextBoxApellido\"]"));
            IWebElement CuadroTextoCurso = driver_JDJOR.FindElement(By.XPath("//*[@id=\"TextBoxCurso\"]"));
            IWebElement CuadroTextoMotivo = driver_JDJOR.FindElement(By.XPath("//*[@id=\"TextBoxMotivo\"]"));
            if (CuadroTextoMatricula.Displayed && CuadroTextoMatricula.Enabled &&
                CuadroTextoNombre.Displayed && CuadroTextoNombre.Enabled &&
                CuadroTextoApellido.Displayed && CuadroTextoApellido.Enabled &&
                CuadroTextoCurso.Displayed && CuadroTextoCurso.Enabled &&
                CuadroTextoMotivo.Displayed && CuadroTextoMotivo.Enabled)
            {
                Console.WriteLine("Prueba exitosa: Los cuadros de texto estan visibles y se pueden editar.");
                Task.Delay(4000).Wait();

                // Agregar información de manera automática
                CuadroTextoMatricula.SendKeys("0123456789");
                CuadroTextoNombre.SendKeys("José");
                CuadroTextoApellido.SendKeys("Martínez");
                CuadroTextoCurso.SendKeys("Desarrollo de Software");
                CuadroTextoMotivo.SendKeys("Tenía una emergencia médica");

                Console.WriteLine("Prueba exitosa: Los datos se han introducido correctamente.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: Los cuadros (o uno en particular) de texto no están visibles y no se pueden editar.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Verificando la Funcionalidad y Agregando Información a los TextBox.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            //////////////////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para guardar los datos colocados en los cuadros de texto //
            //////////////////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement GuardarRegistro = driver_JDJOR.FindElement(By.Id("GuardarDatos"));
            if (GuardarRegistro.Displayed && GuardarRegistro.Enabled)
            {
                Task.Delay(2000).Wait();
                GuardarRegistro.Click();
                Console.WriteLine("Prueba exitosa: Los datos se han guardado correctamente.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: Los datos no se han guardado correctamente.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Guardando el Registro.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            ///////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para editar los datos recientemente guardados //
            ///////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement EditarDatos = driver_JDJOR.FindElement(By.Id("EditarDatos"));
            if (EditarDatos.Displayed && EditarDatos.Enabled)
            {
                Task.Delay(2000).Wait();
                EditarDatos.Click();
                Console.WriteLine("Prueba exitosa: Ahora está editando un registro.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: Algo ha salido mal, No se pudo editar el registro.");
            }

            Task.Delay(2000).Wait();

            IWebElement CuadroTextoMatricula = driver_JDJOR.FindElement(By.Id("TextBoxMatricula"));
            IWebElement CuadroTextoNombre = driver_JDJOR.FindElement(By.Id("TextBoxNombre"));
            IWebElement CuadroTextoApellido = driver_JDJOR.FindElement(By.Id("TextBoxApellido"));
            IWebElement CuadroTextoCurso = driver_JDJOR.FindElement(By.Id("TextBoxCurso"));
            IWebElement CuadroTextoMotivo = driver_JDJOR.FindElement(By.Id("TextBoxMotivo"));

            Task.Delay(2000).Wait();

            //////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para limpiar los datos dentro de los textbox //
            //////////////////////////////////////////////////////////////////////

            // En esta parte se borran los datos de los campos específicos automáticamente
            IWebElement LimpiarTextBox = driver_JDJOR.FindElement(By.Id("LimpiarFormulario"));
            if (LimpiarTextBox.Displayed && LimpiarTextBox.Enabled)
            {
                LimpiarTextBox.Click();
                Console.WriteLine("Prueba exitosa: Los textbox han sido limpiados correctamente.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: Los textbox no han sido limpiados.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Limpiando los TextBox.");

            Task.Delay(2000).Wait();

            // En esta parte se agregan los datos nuevos de manera automática
            CuadroTextoMatricula.SendKeys("0987654321");
            CuadroTextoNombre.SendKeys("Cristóbal");
            CuadroTextoApellido.SendKeys("Colón");
            CuadroTextoCurso.SendKeys("Historia Universal");
            CuadroTextoMotivo.SendKeys("Estaba ayudando a los aborígenes con una tarea");

            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Agregando los datos automáticamente.");

            Task.Delay(4000).Wait();

            IWebElement GuardarRegistro = driver_JDJOR.FindElement(By.Id("GuardarDatos"));
            GuardarRegistro.Click();
            Task.Delay(2000).Wait();
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Editando los Registros.");

        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            //////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para eliminar un dato recientemente guardado //
            //////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement EliminarRegistro = driver_JDJOR.FindElement(By.XPath("//*[@id=\"EliminarDatos\"]"));
            if (EliminarRegistro.Displayed && EliminarRegistro.Enabled)
            {
                Task.Delay(2000).Wait();
                EliminarRegistro.Click();
                Console.WriteLine("Prueba exitosa: El registro fue eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: No se ha podido encontrar o habilitar el botón de eliminación.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - Eliminación de Registros.");

        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        try
        {
            //////////////////////////////////////////////////////////////////////////////////////////////
            // Prueba Automatizada para entrar a la sección "Acerca De" y conocer al autor del programa //
            //////////////////////////////////////////////////////////////////////////////////////////////

            Task.Delay(2000).Wait();

            IWebElement SeccionAcercaDe = driver_JDJOR.FindElement(By.Id("SeccionAcercaDe"));
            if (SeccionAcercaDe.Displayed && SeccionAcercaDe.Enabled)
            {
                Task.Delay(2000).Wait();
                SeccionAcercaDe.Click();
                Console.WriteLine("Prueba exitosa: Ha sido redirigido correctamente a la sección Acerca De.");
            }
            else
            {
                Console.WriteLine("Prueba fallida: No ha sido redirigiso correctamente a la sección Acerca De.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - HU - Entrar a la Sección Acarca De.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }

        ////////////////////////////////////////////////////////////////////////
        // Prueba Automatizada para verificar que estoy en la página Acera De //
        ////////////////////////////////////////////////////////////////////////

        try
        { 
            Task.Delay(2000).Wait();

            string TituloAcercaDe = driver_JDJOR.Title;
            if (TituloAcercaDe == "Acerca De")
            {
                Console.WriteLine("Prueba exitosa: Se encuentra en la sección Acerca De.");
            }
            else
            {
                Console.WriteLine("Pruaba fallida: Algo ha salido mal o No se encuentra en la sección Acerca De.");
            }
            HacerCapturaPantalla(driver_JDJOR, screenshotDirectory, $"Proceso {screenshotCounter++} - HU - Verificando que se está en la Página Acerca De.");
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Prueba fallida: Elemento no encontrado - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se producjo un error durante la prueba: {ex.Message}");
        }
    }

    static void HacerCapturaPantalla(IWebDriver driver, string directory, string fileName)
    {
        try
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = Path.Combine(directory, $"{fileName}.png");
            screenshot.SaveAsFile(filePath);
            Console.WriteLine($"Captura de pantalla guardada: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar la captura de pantalla: {ex.Message}");
        }
    }

    static IWebElement WaitForElementVisible(IWebDriver webDriver, By locator, int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(driver =>
        {
            IWebElement element = driver.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null;
        });
    }
}