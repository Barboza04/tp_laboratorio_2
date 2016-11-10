using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstaciables;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class DniTest
    {
        /// <summary>
        /// Comprueba que el DNI no pueda contener caracteres no numericos
        /// </summary>
        [TestMethod]
        public void DniString()
        {
            string dniPuntos = "33.980.216";
            try
            {
                Instructor inst = new Instructor(3,"Alejandro", "Barboza", dniPuntos, Persona.ENacionalidad.Argentino);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniPuntos);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            string dniLetras = "39a568e7";
            try
            {
                Alumno al = new Alumno(9,"Ignacio", "Miranda", dniLetras, Persona.ENacionalidad.Argentino,Gimnasio.EClases.Natacion);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniLetras);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Comprueba que el DNI no pueda ser nulo
        /// </summary>
        [TestMethod]
        public void DniNull()
        {
            string dniNull = null;
            try
            {
                Alumno al = new Alumno(10, "Nahuel", "Claret", dniNull, Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniNull);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
            
        }

        /// <summary>
        /// Comprueba que el DNI no pueda ser menor a 1
        /// </summary>
        [TestMethod]
        public void DniMenor()
        {
            string dniCero = "0";
            try
            {
                Instructor inst = new Instructor(4,"Agustin", "Cantero", dniCero, Persona.ENacionalidad.Argentino);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniCero);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Comprobar que el DNI no pueda ser mayor a 99.999.999
        /// </summary>
        [TestMethod]
        public void DniMayor()
        {
            string dniMaximo = "100000000";
            try
            {
                Instructor personaUltimo = new Instructor(5,"Franco", "Casartelli", dniMaximo, Persona.ENacionalidad.Extranjero);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniMaximo);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            
        }
    }
}
