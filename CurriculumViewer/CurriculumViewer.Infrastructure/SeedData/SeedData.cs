using CurriculumViewer.Database;
using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurriculumViewer.Infrastructure.SeedData
{
	/// <summary>
	/// A class that provides initial data to populate a database.
	/// </summary>
	public static class SeedData
	{
		private static Teacher teacher1;
		private static Teacher teacher2;
		private static Teacher teacher3;
		private static Teacher teacher4;

		private static TeacherModule teacherModule1;
		private static TeacherModule teacherModule2;
		private static TeacherModule teacherModule3;
		private static TeacherModule teacherModule4;
		private static TeacherModule teacherModule5;
		private static TeacherModule teacherModule6;
		private static TeacherModule teacherModule7;
		private static TeacherModule teacherModule8;
		private static TeacherModule teacherModule9;
		private static TeacherModule teacherModule10;
		private static TeacherModule teacherModule11;
		private static TeacherModule teacherModule12;
		private static TeacherModule teacherModule13;
		private static TeacherModule teacherModule14;
		private static TeacherModule teacherModule15;
		private static TeacherModule teacherModule16;
		private static TeacherModule teacherModule17;
		private static TeacherModule teacherModule18;
		private static TeacherModule teacherModule19;
		private static TeacherModule teacherModule20;
		private static TeacherModule teacherModule21;

		private static Goal goal1;
		private static Goal goal2;
		private static Goal goal3;
		private static Goal goal4;
		private static Goal goal5;
		private static Goal goal6;
		private static Goal goal7;
		private static Goal goal8;
		private static Goal goal9;
		private static Goal goal10;
		private static Goal goal11;
		private static Goal goal12;
		private static Goal goal13;
		private static Goal goal14;
		private static Goal goal15;
		private static Goal goal16;
		private static Goal goal17;
		private static Goal goal18;
		private static Goal goal19;
		private static Goal goal20;
		private static Goal goal21;
		private static Goal goal22;
		private static Goal goal23;
		private static Goal goal24;
		private static Goal goal25;
		private static Goal goal26;
		private static Goal goal27;
		private static Goal goal28;
		private static Goal goal29;
		private static Goal goal30;
		private static Goal goal31;
		private static Goal goal32;
		private static Goal goal33;
		private static Goal goal34;
		private static Goal goal35;
		private static Goal goal36;
		private static Goal goal37;
		private static Goal goal38;
		private static Goal goal39;
		private static Goal goal40;
		private static Goal goal41;
		private static Goal goal42;
		private static Goal goal43;
		private static Goal goal44;
		private static Goal goal45;
		private static Goal goal46;
		private static Goal goal47;
		private static Goal goal48;
		private static Goal goal49;
		private static Goal goal50;
		private static Goal goal51;
		private static Goal goal52;
		private static Goal goal53;
		private static Goal goal54;
		private static Goal goal55;
		private static Goal goal56;
		private static Goal goal57;
		private static Goal goal58;
		private static Goal goal59;
		private static Goal goal60;
		private static Goal goal61;
		private static Goal goal62;
		private static Goal goal63;
		private static Goal goal64;
		private static Goal goal65;
		private static Goal goal66;
		private static Goal goal67;
		private static Goal goal68;
		private static Goal goal69;
		private static Goal goal70;
		private static Goal goal71;
		private static Goal goal72;
		private static Goal goal73;
		private static Goal goal74;
		private static Goal goal75;
		private static Goal goal76;
		private static Goal goal77;
		private static Goal goal78;
		private static Goal goal79;
		private static Goal goal80;
		private static Goal goal81;
		private static Goal goal82;
		private static Goal goal83;
		private static Goal goal84;
		private static Goal goal85;
		private static Goal goal86;
		private static Goal goal87;
		private static Goal goal88;
		private static Goal goal89;
		private static Goal goal90;
		private static Goal goal91;
		private static Goal goal92;
		private static Goal goal93;
		private static Goal goal94;
		private static Goal goal95;
		private static Goal goal96;
		private static Goal goal97;
		private static Goal goal98;
		private static Goal goal99;
		private static Goal goal100;

		private static Module module1;
		private static Module module2;
		private static Module module3;
		private static Module module4;
		private static Module module5;
		private static Module module6;
		private static Module module7;
		private static Module module8;
		private static Module module9;
		private static Module module10;
		private static Module module11;
		private static Module module12;
		private static Module module13;
		private static Module module14;
		private static Module module15;
		private static Module module16;
		private static Module module17;
		private static Module module18;
		private static Module module19;
		private static Module module20;
		private static Module module21;

		private static Course course1;
		private static Course course2;
		private static Course course3;
		private static Course course4;

		private static Exam exam1;
		private static Exam exam2;
		private static Exam exam3;
		private static Exam exam4;
		private static Exam exam5;
		private static Exam exam6;
		private static Exam exam7;
		private static Exam exam8;
		private static Exam exam9;
		private static Exam exam10;
		private static Exam exam11;
		private static Exam exam12;
		private static Exam exam13;
		private static Exam exam14;
		private static Exam exam15;
		private static Exam exam16;
		private static Exam exam17;
		private static Exam exam18;
		private static Exam exam19;
		private static Exam exam20;
		private static Exam exam21;

		private static CourseModule courseModule1;
		private static CourseModule courseModule2;
		private static CourseModule courseModule3;
		private static CourseModule courseModule4;
		private static CourseModule courseModule5;
		private static CourseModule courseModule6;
		private static CourseModule courseModule7;
		private static CourseModule courseModule8;
		private static CourseModule courseModule9;
		private static CourseModule courseModule10;
		private static CourseModule courseModule11;
		private static CourseModule courseModule12;
		private static CourseModule courseModule13;
		private static CourseModule courseModule14;
		private static CourseModule courseModule15;
		private static CourseModule courseModule16;
		private static CourseModule courseModule17;
		private static CourseModule courseModule18;
		private static CourseModule courseModule19;
		private static CourseModule courseModule20;
		private static CourseModule courseModule21;

		private static LearningLine learningLine1;
		private static LearningLine learningLine2;
		private static LearningLine learningLine3;
		private static LearningLine learningLine4;
		private static LearningLine learningLine5;
		private static LearningLine learningLine6;
		private static LearningLine learningLine7;
		private static LearningLine learningLine8;
		private static LearningLine learningLine9;
		private static LearningLine learningLine10;
		private static LearningLine learningLine11;
		private static LearningLine learningLine12;
		private static LearningLine learningLine13;
		private static LearningLine learningLine14;
		private static LearningLine learningLine15;

		private static ExamProgram examProgram1;

		/// <summary>
		/// Provides initial data to populate a database.
		/// </summary>
		/// <param name="context">Represents a session with the database and can be used to query and save instances of your entities.</param>
		public static void EnsurePopulated(ApplicationDbContext context)
		{
			GetModules();
			GetCourses();

			if (!context.Teachers.Any())
			{
				context.Teachers.AddRange(GetTeachers());
			}

			if (!context.Exams.Any())
			{
				context.Exams.AddRange(GetExams());
			}

			if (!context.Goals.Any())
			{
				context.Goals.AddRange(GetGoals());
			}

			if (!context.LearningLines.Any())
			{
				context.LearningLines.AddRange(GetLearningLines());
			}

			if (!context.LearningLineGoals.Any())
			{
				context.LearningLineGoals.AddRange(GetLearningLinesGoals());
			}

			if (!context.LogItems.Any())
			{
				context.LogItems.AddRange(GetLogitems());
			}

			if (!context.Modules.Any())
			{
				context.Modules.AddRange(GetModules());
			}

			if (!context.TeacherModules.Any())
			{
				context.TeacherModules.AddRange(GetTeacherModules());
			}

			if (!context.CourseModules.Any())
			{
				context.CourseModules.AddRange(GetCourseModules());
			}

			if (!context.Courses.Any())
			{
				context.Courses.AddRange(GetCourses());
			}

			if (!context.ExamPrograms.Any())
			{
				context.ExamPrograms.AddRange(GetExamPrograms());
			}

			context.SaveChanges();
		}

		/// <summary>
		/// Seed exam programs.
		/// </summary>
		/// <returns>An array of exam programs.</returns>
		public static List<ExamProgram> GetExamPrograms()
		{
			examProgram1 = new ExamProgram()
			{
				Courses = new List<Course>
				{
					course1,
					course2,
					course3,
					course4
				},
				StartDate = new DateTime(2018, 1, 1),
				EndDate = new DateTime(2019, 1, 1)
			};

			return new List<ExamProgram>
			{
				examProgram1
			};
		}

		/// <summary>
		/// Seed courses.
		/// </summary>
		/// <returns>An array of courses.</returns>
		public static List<Course> GetCourses()
		{
			course1 = new Course()
			{
				Name = "Periode 2.1 Server-side web programming",
				Description = "Verschillende vakken binnen periode IVT2.1 werken met opdrachten – zie de leerwijzers voor meer informatie. De periode kent halverwege, in de weken 4 t/m 7 een project, waarin de vakken Server-side web programming individueel  en UX Design 1 geïntegreerd worden. In periode IVT2.2 ga je verder met de ontwikkeling van de web-applicatie die je hebt gerealiseerd. Je breidt deze dan uit en maakt daarbij gebruik van nieuwe technologieën. Aan het eind van IVT2.1 is er overigens eerst nog het vak Softwareontwerp & -architectuur 2 waarin je bekijkt hoe uitbreidbaar de web-applicatie is. Voor een goed vervolg in IVT2.2 is ongetwijfeld refactoring nodig….",
				Mentor = teacher1,
                StudyYear = 2,
				Modules = new List<CourseModule>
				{
					courseModule1,
					courseModule2,
					courseModule3,
					courseModule4,
					courseModule5
				}
                
			};

			course2 = new Course()
			{
				Name = "Periode 2.2 Client-side web programming",
				Description = "Verschillende vakken binnen periode IVT2.1 werken met opdrachten. Zie de leerwijzers voor meer informatie over die opdrachten. De periode heeft halverwege, in de weken vijf en zes, een individueel project waarin de vakken JavaScript / TypeScript en NoSQL databases geïntegreerd worden. Je gaat in periode IVT2.2 ook verder met de ontwikkeling van de web - applicatie waarmee je in periode IVT2.1 bent begonnen.Je breidt deze uit met een op zichzelf staand systeem dat op client - side technieken is gebaseerd.In week 9 is er een oplevering gepland waarin je een demo geeft van het geïntegreerde systeem.",
				Mentor = teacher2,
			    StudyYear = 2,
                Modules = new List<CourseModule>
				{
					courseModule6,
					courseModule7,
					courseModule8,
					courseModule9,
					courseModule10
				}
			};

			course3 = new Course()
			{
				Name = "Periode 2.3 Data Science",
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig.",
				Mentor = teacher3,
			    StudyYear = 2,
                Modules = new List<CourseModule>
				{
					courseModule11,
					courseModule12,
					courseModule13,
					courseModule14,
					courseModule15,
					courseModule16
				}
			};

			course4 = new Course()
			{
				Name = "Periode 2.4 Infrastructuur",
				Description = "Verschillende vakken binnen periode IVT2.4 werken met opdrachten – zie de leerwijzers voor meer informatie. De periode kent ook een grote opdracht, zeg maar project, waarin de vakken Computernetwerken 2 en Security 1 geïntegreerd worden. Het project vindt plaats aan het einde van de periode.",
				Mentor = teacher4,
			    StudyYear = 3,
                Modules = new List<CourseModule>
				{
					courseModule17,
					courseModule18,
					courseModule19,
					courseModule20,
					courseModule21
				}
			};

			return new List<Course>
			{
				course1,
				course2,
				course3,
				course4
			};
		}

		/// <summary>
		/// Seed course modules.
		/// </summary>
		/// <returns>An array of course modules.</returns>
		public static List<CourseModule> GetCourseModules()
		{
			courseModule1 = new CourseModule()
			{
				CourseId = course1.Id,
				ModuleId = module1.Id
			};

			courseModule2 = new CourseModule()
			{
				CourseId = course1.Id,
				ModuleId = module2.Id
			};

			courseModule3 = new CourseModule()
			{
				CourseId = course1.Id,
				ModuleId = module3.Id
			};

			courseModule4 = new CourseModule()
			{
				CourseId = course1.Id,
				ModuleId = module4.Id
			};

			courseModule5 = new CourseModule()
			{
				CourseId = course1.Id,
				ModuleId = module5.Id
			};

			courseModule6 = new CourseModule()
			{
				CourseId = course2.Id,
				ModuleId = module6.Id
			};

			courseModule7 = new CourseModule()
			{
				CourseId = course2.Id,
				ModuleId = module7.Id
			};

			courseModule8 = new CourseModule()
			{
				CourseId = course2.Id,
				ModuleId = module8.Id
			};

			courseModule9 = new CourseModule()
			{
				CourseId = course2.Id,
				ModuleId = module9.Id
			};

			courseModule10 = new CourseModule()
			{
				CourseId = course2.Id,
				ModuleId = module10.Id
			};

			courseModule11 = new CourseModule()
			{
				CourseId = course3.Id,
				ModuleId = module11.Id
			};

			courseModule12 = new CourseModule()
			{
				CourseId = course3.Id,
				ModuleId = module12.Id
			};

			courseModule13 = new CourseModule()
			{
				CourseId = course3.Id,
				ModuleId = module13.Id
			};

			courseModule14 = new CourseModule()
			{
				CourseId = course3.Id,
				ModuleId = module14.Id
			};

			courseModule15 = new CourseModule()
			{
				CourseId = course3.Id,
				ModuleId = module15.Id
			};

			courseModule16 = new CourseModule()
			{
				CourseId = course3.Id,
				ModuleId = module16.Id
			};

			courseModule17 = new CourseModule()
			{
				CourseId = course4.Id,
				ModuleId = module17.Id
			};

			courseModule18 = new CourseModule()
			{
				CourseId = course4.Id,
				ModuleId = module18.Id
			};

			courseModule19 = new CourseModule()
			{
				CourseId = course4.Id,
				ModuleId = module19.Id
			};

			courseModule20 = new CourseModule()
			{
				CourseId = course4.Id,
				ModuleId = module20.Id
			};

			courseModule21 = new CourseModule()
			{
				CourseId = course4.Id,
				ModuleId = module21.Id
			};

			return new List<CourseModule>
			{
				courseModule1,
				courseModule2,
				courseModule3,
				courseModule4,
				courseModule5,
				courseModule6,
				courseModule7,
				courseModule8,
				courseModule9,
				courseModule10,
				courseModule12,
				courseModule13,
				courseModule14,
				courseModule15,
				courseModule16,
				courseModule17,
				courseModule18,
				courseModule19,
				courseModule20,
				courseModule21
			};
		}

		/// <summary>
		/// Seed modules.
		/// </summary>
		/// <returns>An array of modules.</returns>
		public static List<Module> GetModules()
		{
			module1 = new Module()
			{
				Name = "Server-side web programming individueel",
				Description = @"1. Inleiding
In periode 2.1 staat software ontwikkeling op basis van het Microsoft .NET Core framework centraal. We gaan een web-based applicatie ontwikkelen met een specifiek deel van dit frame-work: ASP.NET Core MVC. 
ASP staat voor Active Server Pages, een Microsoft techniek die sinds het midden van de jaren ’90 beschikbaar is voor het ontwikkelen van dynamische websites welke server-side gegenereerd worden. In tegenstelling tot statische websites die altijd dezelfde (HTML) content hebben, worden dynamische websites door de webserver steeds bij elke aanvraag door de gebruiker/browser opnieuw in elkaar gezet. Zo kan de inhoud variëren en spreken we van dynamische websites.
In 2002 heeft Microsoft de ASP ontwikkelingen geïntegreerd in het .NET framework, het basis ontwikkelplatform van Microsoft dat meerdere talen ondersteunt en een grote hoeveelheid standaard bibliotheken aanbiedt. Sindsdien is ASP.NET doorontwikkeld en zijn er verschillende varianten uitgebracht, waarvan de MVC-variant momenteel veel toegepast wordt. Het Core framework is een vrij nieuwe aanvullende ontwikkeling van Microsoft voor het maken van platform-onafhankelijke software. Het is dus mogelijk om ontwikkelde software op Windows, maar ook bijvoorbeeld op Linux servers in productie te nemen.
ASP.NET Core MVC is gebaseerd op de MVC architectuur en geeft daardoor goede ondersteu-ning voor seperation of concerns: domein model en logica zijn ontkoppeld van de gebruikers interface. Dit heeft de volgende voordelen:
•	De details voor representatie naar de (bv HTML) zijn geïsoleerd
•	Het verhoogt de onderhoudbaarheid van de software
•	Verhoogde testbaarheid

De talen waarin we programmeren zijn HTML en C#. Deze laatste is de OO taal van het .NET-framework die het meest gebruikt wordt en is niet moeilijk te leren met de kennis van Java die je in de eerdere perioden van je opleiding al hebt opgedaan. Verder gebruik je voor het view-gedeelte van de applicatie nog een specifieke syntax die bij de view-engine Razor hoort.

1.1	Positie in de leerlijn
ASP.NET Core MVC is een invulling in de leerlijn Programmeren en introduceert een nieuwe object georiënteerde programmeertaal C#.  Met behulp van C# en het .NET Core framework gaan we een applicatie maken die dynamisch webpagina’s genereert.


1.2	Positie in de periode
ASP.NET Core MVC heeft raakvlakken met UX-Design en bereid je voor op het grote groepsproject wat in lesweek 4 van start gaat. Dit examenonderdeel heeft een individuele opdracht welke wordt ontworpen met behulp van de UX guidelines die in de UX-Design colleges parallel aan deze colleges worden gegeven. Deze opdracht wordt voor dit examenonderdeel beoordeeld op basis van code, het UX-ontwerp levert een bijdrage aan het vak UX-Design. De in deze lessen geleerde theorie en vaardigheid ga je vervolgens toepassen in het grote project wat in lesweek 4 van start gaat.",
				OsirisCode = "EIIN-SSWPRI",
				Exams = new List<Exam> { exam1 },
				Goals = new List<Goal>
				{
					goal1,
					goal2,
					goal3
				},
				Teacher = teacher1
			};

			module2 = new Module()
			{
				Name = "Server-side web programming project",
				Description = @"1. Inleiding
De opleiding informatica is zo ingericht dat je je na de propedeuse verder gaat verdiepen in softwareontwikkeling. In periode IVT2.1 heb je een start gemaakt met server-side web-ontwikkeling met ASP.net MVC Core en UX-design.

In korte tijd heb je al erg veel geleerd en in de weken 4 t/m 7 ga je de vaardigheden toepassen in een project. Samen met een veelal externe opdrachtgever realiseer je een opdracht rond een web-applicatie in ASP.net. Je gaat werken in een team van studenten, waarin ieder zijn rol gaat uitvoeren. Die rollen kunnen ook rouleren, zodat iedereen verschillende verantwoordelijkheden krijgt.

Je gaat in teamverband en met gebruik van de agile ontwikkelmethode Scrum een project uitvoeren. Je laat zien, dat je de die werkwijze nog steeds kunt toepassen. De eisen waaraan de applicatie moet voldoen spreek je af met de product owner. Aan het einde van elke sprint volgt een oplevering waarin je met je groep jullie resultaat presenteert.

Bij het uitvoeren van het project gebruik je je technische vaardigheden, en je past je professionele vaardigheden toe. Presenteren, rapporteren en samenwerken zijn vaardigheden die minstens zo belangrijk zijn als je vaardigheid om een applicatie te maken. Daarbij gebruik je ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.


2. Het project
Om het project tot een succes te maken is een goede structuur onmisbaar. In dit hoofdstuk vind je daarom de structuur, met de belangrijkste rollen en onderdelen van het project.


2.1.	De structuur
Een goede projectstructuur is onmisbaar. In IT-projecten wordt vandaag de dag vaak gebruik gemaakt van
Scrum. Binnen ons project maken we ook gebruik van Scrum. We werken in 4 sprints, elk van 1 week. De eerste sprint, sprint 0, wijkt een beetje af van de latere sprints. Deze wordt gebruikt om je project in te richten, denk daarbij aan:
•	Complete Product Backlog (features, stories)
•	Azure DevOps ingericht:
–	Team Dashboard
–	SCRUM board
–	Sprints (iterations)
–	GIT (inclusief branching configuratie)
–	Development pipeline
–	Release pipeline naar Azure
–	DoD
•	Verdeling SCRUM-rollen (voor sprint 1)

Sprint 0 kent 1 stand-up meeting voor de voortgang en een ‘review’. Deze bevat beperkte functionaliteit voor de product owner. Het gaat erom dat je je infrastructuur op orde hebt. Natuurlijk pak je al wel iets van de backlog op, je gaat immers geen lege projecten leveren… Kies daarom slim enkele items en werk die deels uit zodat je de infrastructuur ook getest hebt.

Voor de sprints 1-3 werken we met:
•	Een sprint planning waarin je, in overleg met de product owner de sprint backlog definieert
•	Drie á vier stand-up meetings.
•	Een sprint review. Het moment waarop je het eindproduct presenteert aan de opdrachtgever. Je houdt een presentatie over het product dat je met je team gemaakt hebt. Je eindproduct en de presentatie worden als geheel beoordeeld met een cijfer.




Elke sprint-bijeenkomst staat in het rooster, echter vaak niet volgens een optimale indeling. In overleg met je begeleider maak je exacte afspraken die af kunnen wijken van het rooster.

De product owner is de persoon die onduidelijkheden over de inhoud van het project kan wegnemen. De sprint planning is hét moment om vragen te stellen. Voor een effectieve en efficiënte sprint is een goede voorbereiding belangrijk. Gebruik je tijd efficiënt om een en ander al voor te bereiden, eventueel met aanwezigheid van de product owner. Daarnaast is het in overleg met de product owner mogelijk om gedurende de sprint contact te hebben. Om dat contact goed te laten verlopen treedt er in het team één lid als contactpersoon op. Die rol kan per sprint rouleren. Vanuit de opleiding wordt ieder project ook begeleid door een docent. De docent heeft de functie van ‘waarnemend product owner’.


2.2.	Teamwork en individuele bijdrage
In het project leidt goede samenwerking tot succes. Het is en blijft wel belangrijk jullie individuele bijdragen afzonderlijk te kunnen beoordelen. In de eerste twee sprints ga je echt als team aan de slag en verwachten we gelijkmatige bijdragen van elk teamlid. In de derde sprint blijf je wel als team werken en lever je ook als team op, maar is er sprake van individuele verantwoordelijkheid voor sprint backlog items (minimaal 2, afhankelijk van grootte en complexiteit). Elk spint backlog wordt dus van begin tot levering aan het gemeenschappelijke product uitgevoerd door 1 persoon, inclusief aantoonbare testen.


2.3.	Aandachtspunten Scrum
Hieronder vind je enkele aandachtspunten, waar je rekening mee dient te houden.

Een actieve houding tijdens en voorafgaand aan de scrum-sessies:

•	Voorafgaand aan een planning sessie de planning opstellen, zodat je goed voorbereid en met concrete vragen de planning sessie ingaat
•	Het bijhouden van het scrum-board
•	Een goede taakanalyse van de product-backlog items
•	Het houden van een Retrospectieve en die dan ook 'laten zien' en toepassen
•	Een effectieve Daily-scrum
•	Een goede review (pak de lijst erbij)
•	Naleven van de (scrum-werkwijze, zoals) Definition of Done
Een concept Definition of Done vind je op BB. Gebruik deze als basis voor de versie in je project.
•	Zichtbare variëteit in je taken (programmeren, testen, schrijven, scrum master, …)

Inzet tijdens de scrum-sessies; ben je (geregeld) actief of louter passief aanwezig.
•	Is het duidelijk wat jouw persoonlijke bijdrage is?
•	Ben je als team actief aan het werk
•	Is de sprintplanning voorbereid
•	Was er een retrospective (aantoonbaar)
•	Is de velocity bepaald
•	Is er een scrum master (duidelijk aanwezig)
•	Verloopt de daily scrum volgens de richtlijnen
•	Is er een burndown chart en wordt deze correct gebruikt
•	Wordt de scrum tool goed gebruikt
•	Wordt de definition of done nageleefd
•	Zijn de backlog items gesplitst in taken
•	Verloopt de review volgens verwachting (zie de checklist van scrum training 2)
•	Is er sprake van een professionele houding en communicatie (zie de tips, do's en don'ts van scrum training 2)",
				OsirisCode = "EIIN-SSWPRP",
				Exams = new List<Exam> { exam2 },
				Goals = new List<Goal>
				{
					goal4,
					goal5,
					goal6
				},
				Teacher = teacher1
			};

			module3 = new Module()
			{
				Name = "UX Design 1",
				Description = @"1.	Inleiding
De module UX-design behandelt de basisbeginselen van het vakgebied rond interface design. Een informaticus moet in een multidisciplinair ontwikkelteam kunnen meedenken bij het vaststellen van user experience requirements. en op basis daarvan binnen bepaalde technische randvoorwaarden de mens-machine interactie realiseren. Daarvoor leer je de basisbeginselen zoals het leren denken vanuit de gebruiker, kleurgebruik en het maken en testen van prototypes. Voor het maken van mockups gebruiken we Balsamiq, een prototyping tool
1.1.	Positie in de leerlijn
Deze module maakt deel uit van de leerlijn UX-design. Deze leerlijn bestaat uit twee modules die de theorie en praktijk behandelen van interface design met behulp van een relationele database. Deze modules komen aan bod in het eerste jaar van de opleiding Informatica, in de periode 1.1 en in het tweede jaar van de opleiding in periode 2.1.


1.2.	Positie in de periode
De lessen in deze module worden verzorgd in de eerste drie weken van de periode. Aan het einde van iedere les volgt een opdracht die in tweetallen of per groep gemaakt wordt. Informatie over deze opdracht vind je in een apart document op Blackboard.


1.3.	Raakvlakken
De module UX-design heeft een link met de module server-side web programming en het project. Op de hiervoor te ontwikkelen app zijn de regels voor UX-design van toepassing.",
				OsirisCode = "EIIN-HCI-1",
				Exams = new List<Exam> { exam3 },
				Goals = new List<Goal>
				{
					goal7,
					goal8,
					goal9,
					goal10
				},
				Teacher = teacher1
			};

			module4 = new Module()
			{
				Name = "Algoritmen & datastructuren",
				Description = @"1.	Inleiding
Deze module is een voortzetting van de leerlijn programmeren zoals die in het eerste studiejaar is begonnen. Aan de orde komen allerlei klassieke datastructuren zoals stacks, queues, lijsten, bomen en maps. Deze datastructuren komen in vele programma’s voor. Het is daarom nodig om over een gedegen kennis van deze datastructuren te beschikken. Met de grote hype rond data science en big data worden algoritmen nóg belangrijker dan ze al waren.

Met datastructuren alleen hebben we uiteraard nog geen programma. Daar horen algoritmen bij. Alhoewel de meeste algoritmen vrij specifiek zijn voor de betreffende applicatie, zijn er een aantal problemen die zo vaak voorkomen dat hier door vele mensen over is nagedacht en er mooie en efficiënte algoritmen voor gevonden zijn. Enkele daarvan zullen wij bekijken.

De stof behandeld in deze module is technologie-onafhankelijk. De stof is van waarde voor het programmeren in vrijwel elke programmeertaal, echter met name Java, C#, Python en C++.

Toekomstbestendig onderwijs
Technologieën (e.g. Android, Java, .NET Core, C#, JavaScript) komen en gaan in hoog tempo. Avans wil jullie opleiden tot toekomstbestendige professionals. Dat betekent dat we jullie geen technologieën aan willen leren, maar de achterliggende concepten. Die concepten gaan namelijk veel langer mee, dus daar heb je ook nog wat aan in de toekomst. Van de andere kant zijn we beroepsonderwijs en praktijkgericht. Met theorie alleen kom je er niet. Je moet het ook toepassen.

Deze module is een voorbeeld van toekomstbestendig onderwijs: de leerdoelen gaan allemaal over concepten. Van de andere kant kun je je deze concepten alleen eigen maken door ermee te oefenen. Dat doen we d.m.v. technologie. Nu is de keuze van de technologie best lastig. Het overgrote deel van de boeken en het online materiaal over algoritmen & datastructuren gebruiken Java, C++ of Python als technologie om mee te oefenen. Van de andere kant staat deze onderwijsperiode in het teken van C# en .NET. We kiezen in deze module voor een tussenweg door aandacht te besteden aan zowel Java als C#.


1.1.	Positie in de leerlijn
Deze module maakt deel uit van de leerlijn Programmeren. 


1.2.	Positie in de periode
De lessen in deze module vallen in lesweek 4 t/m 9 (lesweek 8 is onderwijsluw). De module heeft geen relatie met de andere modules. De module wordt afgesloten met een schriftelijk tentamen in lesweek 10.",
				OsirisCode = "EIIN-ALGDAT",
				Exams = new List<Exam> { exam4 },
				Goals = new List<Goal>
				{
					goal11,
					goal12,
					goal13,
					goal14,
					goal15,
					goal16,
					goal17,
					goal18,
					goal19,
					goal20,
					goal21,
					goal22
				},
				Teacher = teacher1
			};

			module5 = new Module()
			{
				Name = "Softwareontwerp & -architectuur 2",
				Description = @"1.	Inleiding
In de afgelopen weken heb je webapplicaties leren ontwikkelen in ASP.NET Core MVC en heb je een project uitgevoerd waarin je met een groepje een wat grotere applicatie hebt gemaakt. Het toepassen van MVC geeft de code van je applicatie structuur en dat komt o.a. onderhoudbaarheid en testbaarheid ten goede.
Toch was de focus, en daarmee de applicatie die je hebt ontwikkeld, gericht op een op zichzelf staande webapplicatie met eigen database. In de realiteit zal de software die je ontwikkelt gerelateerd zijn aan een verzameling applicaties, al dan niet zelf ontwikkeld, ofwel een applicatielandschap.
De module Softwareontwerp & -architectuur 2 behandelt ontwerpprincipes en concepten waarmee je van je autonome webapplicatie een applicatie maakt die onderdeel kan zijn van een applicatielandschap. De inzichten ga je toepassen op de applicatie die je tijdens het project hebt ontwikkeld aanpassen zodat deze een goede basis vormt voor de vervolgperiode IVT2.2. Je zult in die periode ook een project uitvoeren waarin je een nieuwe webapplicatie ontwikkelt. De ASP.NET applicatie uit IVT2.1 integreer je hiermee zodat ze samen een klein applicatielandschap vormen. 


1.1.	Positie in de leerlijn
Deze module maakt deel uit van de leerlijn software design and architecture en is een vervolg op Softwareontwerp & -architectuur 1.


1.2.	Positie in de periode
De lessen in deze module worden verzorgd vanaf week 7 t/m de laatste week van de periode.


1.3.	Raakvlakken
De module is de schakel die periodes IVT2.1 en IVT2.2 met elkaar verbindt.",
				OsirisCode = "EIIN-SOFA2",
				Exams = new List<Exam> { exam5 },
				Goals = new List<Goal>
				{
					goal23,
					goal24,
					goal25,
					goal26,
					goal27,
					goal28,
					goal29,
					goal30,
					goal31,
					goal32
				},
				Teacher = teacher1
			};

			module6 = new Module()
			{
				Name = "Client-side web frameworks",
				Description = @"1. Inleiding
Angular is een open source JavaScript web applicatie framework dat is ontwikkeld door Google. Angular is een
raamwerk voor het opzetten van een client-side model-view-controller (MVC)-architectuur. Client-side betekent dat
de code van een Angular webapplicatie uitgevoerd wordt aan de kant van de gebruiker, en niet, zoals je in periode
2.1 bij het .NET framework hebt gezien, op de server. Angular draait in de webbrowser, gebruikmakend van de
JavaScript engine.
Angular staat niet helemaal op zichzelf. De code van het framework is gevat in een HTML pagina die eerst opgehaald
moet worden op de server. Dat hoeft echter maar één keer per sessie te gebeuren, bij het openen van de applicatie
in de browser. Daarna communiceert Angular vanaf de client met een of meer servers om daar gegevens op te
halen. Angular wordt daarom ook wel een Single Page Application (SPA) technologie genoemd.
De MVC (of eigenlijk MVVM-) architectuur maakt het mogelijk om robuuste, stabiele, modulaire en goed
onderhoudbare applicaties te maken. Daarnaast maak je met Angular, in combinatie met NodeJS, een full-stack
webapplicatie die zowel op de server als op de client gebruik maakt van één programmeertaal: JavaScript.
Met de komst van Angular 4 (of kortweg Angular) is er een programmeertaal om JavaScript heen gemaakt die het
mogelijk maakt om object-georiënteerd te programmeren op een manier zoals je die ook uit Java en C# kent. Deze
taal is TypeScript.


1.1. Positie in de leerlijn
Deze module maakt deel uit van de leerlijn Programmeren en is een vervolg op het examenonderdeel
Programmeren 4.


1.2. Positie in de periode
Dit examenonderdeel is een voorbereiding voor de examenonderdelen ""single page application web
development individueel"" en ""single page application web development project"" die later in de periode aan
bod komen.De lessen van dit examenonderdeel vallen in lesweek 1 t / m 4 en worden afgesloten met een
project in lesweek 4.",
				OsirisCode = "EIIN-CSWF",
				Exams = new List<Exam> { exam6 },
				Goals = new List<Goal> { goal33 },
				Teacher = teacher2
			};

			module7 = new Module()
			{
				Name = "No-SQL databases",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend",
				OsirisCode = "EIIN-NSQLDB",
				Exams = new List<Exam> { exam7 },
				Goals = new List<Goal> { goal34 },
				Teacher = teacher2
			};

			module8 = new Module()
			{
				Name = "Client-side web programming individueel",
				Description = @"1. Inleiding
Periode IVT2.1 en IVT2.2 vormen een doorlopend semester waarin je aan de slag gaat met de theorie en
praktijk van de ontwikkeling van webapplicaties. In periode IVT2.1 staat de ASP.NET Core MVC technologie
centraal. In periode IVT2.2 werk je met JavaScript, TypeScript en NoSQL technologie, samengevat in de term
Single Page web application development.
Om je individuele kennis van Single Page Applications verbonden met een NoSQL database te ontwikkelen en
te beoordelen bevat de periode een individueel project, waarin jij jouw kennis en vaardigheden aantoont. Deze
leerwijzer beschrijft de onderwijsaspecten en de kaders van dat individuele project. De concrete opdracht die
je uitvoert wordt in een apart document beschreven.
Periode IVT2.2 bevat ook een groepsproject. Dat project staat los van het individuele project en is beschreven
in een aparte leerwijzer. Je vindt alle benodigde documenten bij het onderwijsmateriaal van periode IVT2.2 op
Blackboard.


1.1. Positie in de leerlijn
Het project maakt formeel geen onderdeel uit van een leerlijn. De theorie en praktijk van het project sluiten
echter aan bij de stof uit de leerlijnen Programmeren en Databases.


1.2. Positie in de periode
Het individuele project volgt na een periode van vier weken waarin je trainingen hebt gevolgd over de theorie
en praktijk van single page web applications. Je hebt les gehad in JavaScript/TypeScript en in NoSQL databases,
en je kunt beide integreren tot een full stack web application, waarin je zowel de database, de serverside, de
front-end webapplicatie en de userinterface hebt ingericht en ontwikkeld.
Het individuele project voer je uit in de weken vijf en zes van de onderwijsperiode. Op de vrijdag in de tweede
week van het project volgt de beoordeling.
Het individuele project is een voorbereiding om het groepsproject in periode IVT2.2 uit te kunnen voeren. Dat
groepsproject start in week zeven en duurt drie onderwijsweken.",
				OsirisCode = "EIIN-CSWPI",
				Exams = new List<Exam> { exam8 },
				Goals = new List<Goal> { goal35 },
				Teacher = teacher2
			};

			module9 = new Module()
			{
				Name = "Client-side web programming project",
				Description = @"Periode IVT2.1 en IVT2.2 vormen een doorlopend semester waarin je aan de slag gaat met de theorie en praktijk
van de ontwikkeling van webapplicaties. In periode IVT2.1 staat de ASP.NET Core MVC technologie centraal. In
periode IVT2.2 werk je met JavaScript, TypeScript en NoSQL technologie, samengevat in de term Single Page web
application development.
In zowel periode IVT2.1 als in IVT2.2 voer je een groepsproject uit. In dit project realiseer je met je studentgroep
een applicatie voor een opdrachtgever. De kaders voor het project dat je in periode IVT2.1 uitvoerde staan
beschreven in de leerwijzer van dat project op Blackboard. Het document dat je nu leest beschrijft de
onderwijsaspecten en de kaders van het groepsproject in periode IVT2.2.
De projecten uit periode 2.1 en 2.2 hebben als gemeenschappelijke context het onderwerp ‘web application
development’ in brede zin. Je werkt in ieder van de twee periodes in een groep aan de ontwikkeling van een
webapplicatie die gezamenlijk een realistisch praktijkprobleem oplossen. De systemen hebben een nauwe
interactie, wisselen onderling informatie uit, en bieden beide een user interface op het systeem dat hun eigen
domein implementeert.
Bij het uitvoeren van het project gebruik je je technische vaardigheden en pas je je professionele vaardigheden toe.
Presenteren,rapporteren en samenwerken zijn minstenszo belangrijk als je vaardigheid om een applicatie te
maken. Je gebruikt ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration
management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele
proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.",
				OsirisCode = "EIIN-CSWPP",
				Exams = new List<Exam> { exam9 },
				Goals = new List<Goal> { goal36 },
				Teacher = teacher2
			};

			module10 = new Module()
			{
				Name = "Professionele vaardigheden 3",
				Description = @"1.	Inleiding
In de eerste twee perioden van jaar 2 werk je zowel samen als individueel aan een project waarin je software ontwikkelt voor een product owner. Dit komt erg overeen met wat je gaat doen in het bedrijfsleven en, ter voorbereiding hierop, je stage en afstuderen. Het is belangrijk om te ontdekken wat je sterke eigenschappen zijn en waar je verbeterpunten liggen zodat je de juiste ontwikkeling kan doormaken tot je aan je stage begint. In professionele vaardigheden 3 ga je reflecteren op je vaardigheden in individueel werk en als onderdeel van een team. Hierover schrijf je een persoonlijk ontwikkelingsplan wat jou gaat helpen je voor te bereiden op je stage. Alle organisatorische informatie voor die module vind je in dit document.


Positie in de leerlijn
Om te functioneren als een professional in de ICT moet je je kennis en vaardigheden kunnen toepassen in de praktijk. Wij noemen de combinatie van kennis, vaardigheden en attitude, oftewel houding, een competentie.  De vaardigheden zijn onder te verdelen in vakinhoudelijke vaardigheden als bijvoorbeeld programmeren of testen en professionele vaardigheden zoals projectmatig kunnen werken, communiceren of presenteren. Binnen  de opleiding informatica is er een leerlijn professionele vaardigheden die zich over drie jaar uitstrekt. 

In deze periode worden de volgende professionele vaardigheden behandeld: 
•	Reflecteren
•	Formuleren van leerdoelen
•	Schrijven van een persoonlijk ontwikkelingsplan.

Deze vaardigheden bereiden je voor op je stage en afstuderen, waarin je ook gaat werken aan de leerdoelen die je hebt opgesteld in een persoonlijk ontwikkelingsplan.


Positie in de periode
Je volgt professionele vaardigheden 3 in de laatste weken van periode 2 (week 7, 8 en 9). In deze weken reflecteer je op je werk uit periode 1 en 2 van dit jaar. In week 7 reflecteer je op jezelf, in week 8 op jezelf binnen een team en in week 9 schrijf je je persoonlijk ontwikkelingsplan. ",
				OsirisCode = "EIIN-PROVA3",
				Exams = new List<Exam> { exam10 },
				Goals = new List<Goal> { goal37 },
				Teacher = teacher2
			};

			module11 = new Module()
			{
				Name = "Bedrijfsprocessen 2",
				Description = @"1.	1. Inleiding
Bedrijfsprocessen 2 wordt aangeboden in het 3e kwartaal van het 2e leerjaar van de Informatica-opleiding van de Academie voor Engineering en ICT (AE&I) en bevat een introductie tot de bedrijfskunde.


1.1	Positie in de leerlijn
Bedrijfsprocessen 2 is een zelfstandig onderwerp.


1.2	Positie in de periode
Een I afgestudeerde zal niet in een vacuüm werken. Hij krijgt te maken met klanten, programmeert om processen te kunnen verbeteren of innoveren opdat organisaties hun strategische doelen beter kunnen behalen. Maar wat is nu eigenlijk een organisatie?. Hoe wordt het reilen en zeilen bepaald?. Welke processen spelen zich daar af?. Bedrijfsprocessen 2 verschaft de basiskennis benodigd voor het beantwoorden van deze vragen. Binnen deze periode heeft het een nauwe relatie met business intelligence front end.",
				OsirisCode = "EIIN-BDRPR2",
				Exams = new List<Exam> { exam11 },
				Goals = new List<Goal>
				{
					goal38,
					goal39,
					goal40
				},
				Teacher = teacher3
			};

			module12 = new Module()
			{
				Name = "Introductie Business Intelligence",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend",
				OsirisCode = "EIIN-INTROBU",
				Exams = new List<Exam> { exam12 },
				Goals = new List<Goal> { },
				Teacher = teacher3
			};

			module13 = new Module()
			{
				Name = "Technieken Business Intelligence",
				Description = @"1.	Inleiding
Beginselen van bedrijfsprocessen (Bedrijfsprocessen 1) worden aangeboden in het 1ste kwartaal van het 1ste leerjaar van de Informatica-opleiding van de Academie voor Engineering en ICT (AE&I) en bevat met name technieken voor het modelleren van bedrijfsprocessen.


1.1	Positie in de leerlijn
Business Intelligence (Front-end) maakt onderdeel uit van de leerlijn Bedrijfsprocessen. Bedrijfsprocessen 1 introduceert een omschrijving van bedrijfsprocessen en introduceert activiteitendiagrammen als tekentechniek om deze in beeld te brengen. Verder wordt het verband tussen bedrijfsprocessen en automatisering daarvan aangegeven. Bedrijfsprocessen 2 zal, in het 2de leerjaar, nader ingaan op de inhoud van specifieke bedrijfsprocessen.


1.2	Positie in de periode
Business Intelligence (front-end) is nauw verbonden met de andere vakken uit deze periode zoals Bedrijfsprocessen 2, Business-Intelligence (back-end) en in iets mindere mate Big data.",
				OsirisCode = "EIIN-TECHBU",
				Exams = new List<Exam> { exam13 },
				Goals = new List<Goal>
				{
					goal41,
					goal42,
					goal43,
					goal44,
					goal45
				},
				Teacher = teacher3
			};

			module14 = new Module()
			{
				Name = "Project Business Intelligence",
				Description = @"1.	Inleiding
Business Intelligence Backend wordt aangeboden in het 3de kwartaal van het 2de leerjaar van de Informatica-opleiding van de Academie voor Engineering en ICT (AE&I) en bevat met name theorie en praktijk van ‘datawarehouses’.


1.1	Positie in de leerlijn
Business Intelligence Backend is een specialisatie binnen de leerlijn ‘Databases’. Nadat in ‘Relationele Databases 1/2/3’ de beginselen van relationele databases zijn gemaakt, komt nu het datawarehouse als niet-genormaliseerde database aan bod.


1.2	Positie in de periode
Business Intelligence Backend heeft veel raakpunten met andere vakken uit deze periode. Het kan beschouwd worden als een voortzetting van Business Intelligence Frontend, waar in die module vooral toepassingsmogelijkheden behandeld werden, staat nu de onderliggende (technische) structuur centraal. Daarnaast is er een relatie met Technical English; onderwijsmateriaal wordt in de Engelse taal aangeboden. Dit geldt overigens niet voor de colleges.",
				OsirisCode = "EIIN-PROJBU",
				Exams = new List<Exam> { exam14 },
				Goals = new List<Goal>
				{
					goal46,
					goal47,
					goal48,
					goal49,
					goal50,
					goal51,
					goal52
				},
				Teacher = teacher3
			};

			module15 = new Module()
			{
				Name = "Big Data",
				Description = @"1.	Introduction
Big Data is taught in the third block of year 2 as part of the Informatics curriculum of the Academy of Engineering & ICT (AE&I). Its contents, in short, contains an introduction to the concept ‘Big Data’ and some of its practical applications. 


1.1	Positioning in the study programme
Although Big Data is an autonomous subject, prior knowledge of databases and business intelligence is beneficial.


1.2	Positioning in the period
Big Data heavily touches upon other subjects in this period. In a way, Big Data might be considered a sequel of Business Intelligence, but one where the use of (more) unstructured data and/or the ability not only to analyse historic data, but also to predict  the future (data mining/machine learning). In addition, Technical English is applied in the sense that teaching material is in the English language. However, this does not go for the lectures.",
				OsirisCode = "EIIN-BIGDAT",
				Exams = new List<Exam> { exam15 },
				Goals = new List<Goal>
				{
					goal53,
					goal54,
					goal55,
					goal56,
					goal57
				},
				Teacher = teacher3
			};

			module16 = new Module()
			{
				Name = "Technical English",
				Description = @"1	Introduction
English is a major part of modern international business communication and it is important to IT professionals for various reasons. English is used in a variety of contexts from programming languages to everyday communication with other professionals and customers. Being able to communicative effectively in English requires knowledge of structures and practice. The module Technical English will develop students’ linguistic foundations for work, training or further study.

Technical English focuses on language learning and the explicit teaching of the structure, linguistic features and application. Through close study of language and meaning, students develop skills that enable them to use different registers of spoken and written English so they can communicate effectively in a range of contexts and for a variety of purposes in order to become effective cross-cultural users of the language. 

Technical English provides opportunities for students to engage reflectively and critically with a broad range of spoken and written texts. Within this module students regularly use the language modes of listening, speaking, reading, and writing to develop their communicative skills in English for a range of purposes, audiences and contexts. 

English is particularly important for IT professionals as it forms the basis of many operating systems and software programmes that are produced in the US or by other countries in English. In addition, a vast majority of information on the Internet is in English. English as the primary IT language has streamlined computer processing and electronic communication. 

For these reasons, it is important that IT professionals are able to communicate clearly, effectively, and without any misunderstandings. They need to be able to communicate with many different professionals in and outside their organisations, including the more technically orientated professional and non-technicians. 

Communicating with such a wide variety of professionals requires a broad skill base in English. Technicians often require clear and concise use of language while communication with non-technicians may require a more extensive use of linguistic skills. A good command and understanding of the English language will help students achieve this.   


1.1	Positioning in the study programme 
This is the second of two English courses that you will participate in. Basic English, in block 3 of last year, introduced you to IT specific vocabulary and formal correspondence with clients and colleagues. Students also familiarised themselves with reading texts on various topics within the field. 

This course, Technical English, is taught in the third block of year 2 and deals with acquiring vocabulary specific to Business Intelligence, Big Data, data warehousing, the Internet of Things and formal communication with executives. To demonstrate the mastery of such vocabulary, and to show that they can communicate professionally, students will be required to write an executive summary and demonstrate their ability to participate in meetings. 


1.2	Positioning in the block 
Classes will be taught in weeks 1 – 7, 1.5 hours a week. The course aims to be closely connected to other courses that are taught in the same block. Texts will deal with topics discussed in other classes and the writing assignment simulates real contact with clients. ",
				OsirisCode = "EIIN-TECHENG",
				Exams = new List<Exam> { exam16 },
				Goals = new List<Goal>
				{
					goal58,
					goal59,
					goal60,
					goal61,
					goal62
				},
				Teacher = teacher3
			};

			module17 = new Module()
			{
				Name = "Security 1",
				Description = @"1.	Inleiding

1.1.	Positie in de leerlijn
Deze module maakt deel uit van de leerlijn Security.


1.2.	Positie in de periode
De lessen in deze module worden verzorgd in de weken 4 t/m 7 van de periode. De module Computernetwerken 2 heb je dan al afgerond. De kennis uit Computernetwerken 2 zul je nodig hebben bij Security 1. Aan het einde van de periode volgt een project waarin je de kennis en kunde uit Computernetwerken 2 en Security 1 geïntegreerd toepast. 


1.3.	Raakvlakken
De module Security 1 heeft een link met de module Computer Netwerken 2 in IVT2.4. Verder zul je merken dat kennis en kunde met betrekking tot programmeren en databases ook in deze module terugkomen.",
				OsirisCode = "EIIN-SECU1",
				Exams = new List<Exam> { exam17 },
				Goals = new List<Goal>
				{
					goal63,
					goal64,
					goal65,
					goal66,
					goal67,
					goal68,
					goal69,
					goal70,
					goal71,
					goal72,
					goal73,
					goal74,
					goal75,
					goal76
				},
				Teacher = teacher4
			};

			module18 = new Module()
			{
				Name = "Computernetwerken 2",
				Description = @"1.	Inleiding
In periode 1.4 heb je tijdens Computernetwerken 1 een introductie in netwerken gehad. Die module heeft je een conceptuele basis gegeven waar we in deze periode op voortbouwen. Computernetwerken 2 geeft verdieping op voornamelijk de applicatielaag uit het TCP/IP-model, en je past de verkregen kennis toe in uitdagende opdrachten. 


1.1	Positie in de leerlijn
Computernetwerken 2 is een continuering van de leerlijn Computernetwerken. In periode 1.4 is deze leerlijn ingezet met Computernetwerken 1.


1.2	Positie in de periode
De stof van Computernetwerken 2 is noodzakelijk om Security 1 te begrijpen. De kennis die je opdoet bij Computernetwerken 2 heb je nodig voor het integratieve project aan het einde van de periode.",
				OsirisCode = "EIIN-CONETW2",
				Exams = new List<Exam> { exam18 },
				Goals = new List<Goal>
				{
					goal77,
					goal78,
					goal79,
					goal80,
					goal81,
					goal82,
					goal83,
					goal84
				},
				Teacher = teacher4
			};

			module19 = new Module()
			{
				Name = "Verdieping ICT",
				Description = @"Inleiding
Verdieping ICT wordt aangeboden in het 4de kwartaal van het 2de leerjaar van de Informatica-opleiding van de Academie voor Engineering en ICT (AE&I).

Via het onderdeel Verdieping ICT biedt de opleiding Informatica studenten de mogelijkheid om een specifieke competentie, naar eigen keuze van de student, (verder) te ontwikkelen. Het gaat dan wel om een competentie die nu niet in het onderwijsprogramma is opgenomen, niet in het voorafgaande noch in het komende deel van het curriculum. Dit onderdeel geeft een individuele student de mogelijkheid om zelf een deel van haar/zijn studieprogramma samen te stellen, ter grootte van 2 European Credits (ECs) of 56 uur. 


Positie binnen leerlijn
Verdieping ICT is een zelfstandige module en maakt geen onderdeel uit van een leerlijn.


Positie binnen periode
Verdieping ICT heeft geen directe raakpunten met andere vakken uit deze periode.",
				OsirisCode = "EIIN-VERDICT",
				Exams = new List<Exam> { exam19 },
				Goals = new List<Goal>
				{
					goal85,
					goal86,
					goal87,
					goal88
				},
				Teacher = teacher4
			};

			module20 = new Module()
			{
				Name = "Duurzame Ontwikkeling 2",
				Description = @"1.	Inleiding
Duurzaamheid is een steeds belangrijker onderdeel van moderne bedrijfsvoering. Zonder een duurzame strategie wordt het lastig om op een lange termijn een bedrijf draaiende te houden. Maar wat is duurzaam, en hoe bereik je duurzaamheid in een organisatie waarin ICT een grote rol speelt? Daarover leer je in de module Duurzame Ontwikkeling.
In de tweede periode van de propedeuse willen we onze horizon verruimen en bekijken welke impact ICT op mensen, aarde en welvaart heeft. De student wordt zich bewust van de duurzaamheidsthematiek en de rol en mogelijkheden van de ICT erin. 
Alle organisatorische informatie voor deze module vind je in dit document.


1.1.	Positie in de leerlijn
Deze module maakt deel uit van de leerlijn Duurzame Ontwikkeling. De leerlijn Duurzame Ontwikkeling bestaat uit twee modules die theorie en voorbeelden van duurzaamheidsvraagstukken behandelen. Deze modules komen aan bod in het eerste en tweede jaar van de opleiding Informatica, in de periodes 1.2 en 2.4.


1.2.	Positie in de periode
De lessen in de eerste module worden verzorgd in week 1, 2 en 3 van de periode. In week 4 vindt toetsing plaats door middel van een MC-Toets.


1.3.	Raakvlakken
De module Duurzame Ontwikkeling 2 heeft een link met Agile en/of Lean Software Ontwikkeling. Tijdens de oefeningen in de les en tijdens huiswerk gaat de student onderzoek op internet doen en de resultaten hiervan samenvatten. Het resultaat van de huiswerkopdracht is een verslag die moet voldoen aan de eisen van rapportagetechniek (boek van Elling).",
				OsirisCode = "EIIN-DZONT2",
				Exams = new List<Exam> { exam20 },
				Goals = new List<Goal>
				{
					goal89,
					goal90,
					goal91,
					goal92
				},
				Teacher = teacher4
			};

			module21 = new Module()
			{
				Name = "Onderzoeksvaardigheden 2",
				Description = @"1.	Inleiding
In de vierde periode van het tweede jaar volg je een cursus Onderzoeksvaardigheden 2: Kritisch denken om je te ondersteunen het ontwikkelen van vaardigheden om te kunnen redeneren en argumenteren.
Alle organisatorische informatie voor die module vind je in dit document.


Positie in de leerlijn
Om te functioneren als een professional in de ICT moet je je kennis en vaardigheden kunnen toepassen in de praktijk. Wij noemen de combinatie van kennis, vaardigheden en attitude, oftewel houding, een competentie.  De vaardigheden zijn onder te verdelen in vakinhoudelijke vaardigheden als bijvoorbeeld programmeren of testen en professionele vaardigheden zoals projectmatig kunnen werken, communiceren, presenteren of kritisch denken. Binnen  de opleiding informatica is er een leerlijn onderzoekend vermogen.

In deze periode wordt er gericht op het ontwikkelen van vaardigheden voor kritisch denken. Deze vaardigheden zullen van pas komen tijdens je stage opdracht, maar ook tijdens andere modules waarin je een mening vormt of een verslag schrijft.


Positie in de periode
Je volgt zes lessen van 2 lesuren. Lessen vinden plaats in lesweken 1, 2, 3, 5, 6 en 7.


Raakvlakken
Onderzoeksvaardigheden en schrijfvaardigheden",
				OsirisCode = "EIIN-ORVA2",
				Exams = new List<Exam> { exam21 },
				Goals = new List<Goal>
				{
					goal93,
					goal94,
					goal95,
					goal96,
					goal97,
					goal98,
					goal99,
					goal100
				},
				Teacher = teacher4
			};

			return new List<Module>
			{
				module1,
				module2,
				module3,
				module4,
				module5,
				module6,
				module7,
				module8,
				module9,
				module10,
				module11,
				module12,
				module13,
				module14,
				module15,
				module16,
				module17,
				module18,
				module19,
				module20,
				module21
			};
		}

		/// <summary>
		/// Seed goals.
		/// </summary>
		/// <returns>An array of goals.</returns>
		public static List<Goal> GetGoals()
		{
			// EIIN-SSWPRI Server-side web programming individueel
			goal1 = new Goal
			{
				Bloom = "Understand",
				Description = @"Kan programmeerconcepten in eigen woorden uitleggen, zodanig dat hij weet wat het nut ervan is:
Loose coupling(Dependency Injection)
Test Driven Development
Mocking
Model View Controller Architectuur
Repository"
			};

			goal2 = new Goal
			{
				Bloom = "Understand",
				Description = @"Kan in eigen woorden basisconcepten van het ASP.NET platform uitleggen, zodat hij weet wat het nut ervan is bij de realisatie van een  webapplicatie:
Microsoft - MVC Framework
View Engine(Razor) C#"
			};

			goal3 = new Goal
			{
				Bloom = "Understand",
				Description = @"Kan in eigen woorden programmeerconstructies van de taal C# uitleggen, zodat dat hij er effectief over kan communiceren met mede-C#-programmeurs:
Properties
Object / Collection initializers
Extension method
Lambda expressions
Automatic type inference
LINQ"
			};

			// EIIN-SSWPRP Server-side web programming project
			goal4 = new Goal
			{
				Bloom = "Apply",
				Description = @"Kan programmeerconcepten toepassen mbv een tool,
				zodanig dat hij een webapplicatie kan realiseren in een team:
Loose coupling(Dependency Injection),
				dmv een DI - tool(bv Ninject)
Test Driven Development
Mocking dmv een tool voor mocking(bv Moq)
Model View Controller Architectuur
Repository
ORM - tool(bv Entity Framework)"
			};

			goal5 = new Goal
			{
				Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"

			};

			goal6 = new Goal
			{
				Bloom = "Apply",
				Description = @"Kan zelfstandig mbv aangereikt materiaal een nieuw programmeerconcept eigen maken, zodanig dat dit toegepast wordt op het ontwikkelen van een WebApplicatie  in een team
WebAPI
Identity Framework"
			};

			// EIIN-HCI-1 UX Design 1
			goal7 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student herkent en benoemt UX design aspecten in bestaande user interfaces, zodanig dat hij deze kan toepassen in zijn eigen ontwerpen."
			};

			goal8 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student maakt een interaction design voor een applicatie, zodanig dat hij daarmee bij de gebruiker een vooraf gekozen beleving realiseert."
			};

			goal9 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student maakt een interaction design voor een applicatie, zodanig dat de door de gebruiker gestelde doelen gehaald worden wat betreft benodigde informatie en acties."
			};

			goal10 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student voert een usability test uit op enkele bestaande user interfaces, zich daarbij baserend op criteria uit de literatuur."
			};

			// EIIN - ALGDAT Algoritmen & datastructuren
			goal11 = new Goal
			{
				Bloom = "Apply",
				Description = @"Rekencomplexiteit en geheugencomplexiteit van algoritmes kunnen bepalen."
			};

			goal12 = new Goal
			{
				Bloom = "Apply",
				Description = @"Begrijpen en kunnen toepassen van recursie."
			};

			goal13 = new Goal
			{
				Bloom = "Apply",
				Description = @"Abstracte datastructuren kunnen kiezen en toepassen in praktische situaties."
			};

			goal14 = new Goal
			{
				Bloom = "Apply",
				Description = @"Kunnen toepassen van datastructuren uit het Collections Framework: List, ArrayList, LinkedList, Deque, HashMap, TreeMap, TreeSet, HashSet, SortedSet, SortedMap, LinkedHashMap."
			};

			goal15 = new Goal
			{
				Bloom = "Apply",
				Description = @"Kunnen toepassen van algoritmen uit het Collections Framework: de klasses Collections en Arrays."
			};

			goal16 = new Goal
			{
				Bloom = "Apply",
				Description = @"Een linked lijst kunnen implementeren."
			};

			goal17 = new Goal
			{
				Bloom = "Apply",
				Description = @"Een stack en queue kunnen implementeren m.b.v. een linked list."
			};

			goal18 = new Goal
			{
				Bloom = "Apply",
				Description = @"Een binaire (zoek)boom kunnen implementeren."
			};

			goal19 = new Goal
			{
				Bloom = "Understand",
				Description = @"Hash maps begrijpen."
			};

			goal20 = new Goal
			{
				Bloom = "Apply",
				Description = @"Generieke typen begrijpen en kunnen toepassen op de klasses uit het Collections Framework."
			};

			goal21 = new Goal
			{
				Bloom = "Apply",
				Description = @"De meest voorkomende constructies van de taal Java begrijpen en kunnen toepassen."
			};

			goal22 = new Goal
			{
				Bloom = "Apply",
				Description = @"Begrijpen en kunnen toepassen van ontwerpprincipes, zoals “program to an interface” of “inheritance vs delegation”."
			};

			// EIIN-SOFA2 Softwareontwerp & -architectuur 2
			goal23 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student voegt een Web API toe aan een bestaande webapplicatie (e.g. RESTful view mbv JSON), zodanig dat de student de toegevoegde waarde van MVC kan uitleggen."
			};

			goal24 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student *ontwerpt* een mashup, zodanig dat hij inziet dat MVC zowel client-side als server-side toegepast wordt, binnen dezelfde mashup."
			};

			goal25 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan, op grond van gegeven requirements, een lagenstructuur beargumenteerd kiezen en toepassen, zodanig dat elke laag een unieke en afgebakende verantwoordelijkheid heeft, wat leidt tot een modulaire applicatie van goede kwaliteit (kwaliteit: uitbreidbaarheid, onderhoudbaarheid, testbaarheid, herbruikbaarheid, managen complexiteit)."
			};

			goal26 = new Goal
			{
				Bloom = "Understand",
				Description = @"De student kan reflecteren op de rol van MVC in een mashup, zodanig dat hij ook de nadelen in eigen uit woorden uit kan leggen en op de hoogte is van de technologische ontwikkelingen op dit gebied (e.g. isomorphic Javascript)."
			};

			goal27 = new Goal
			{
				Bloom = "Understand",
				Description = @"De student kan, in eigen worden, de varianten van de MVC-familie benoemen en de onderlinge verschillen uitleggen, zodanig dat spraakverwarring rondom MVC wordt weggenomen."
			};

			goal28 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan met behulp van een UML component diagram de development view van een systeem opstellen en onderbouwen, zodanig hij efficiënt en effectief kan met softwareontwikkelaars kan communiceren over de structuur van de softwareapplicatie."
			};

			goal29 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan met behulp van een UML deployment diagram de physical view van een systeem opstellen en onderbouwen, zodanig dat hij kan uitleggen hoe de gemaakte software mapt op hardware componenten en welke communicatie daarbij gebruikt wordt."
			};

			goal30 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student ontwerpt en realiseert een (level 2) RESTful Web API volgens gangbare ontwerpregels, zodanig dat een mashup mogelijk wordt gemaakt.(note: ook de doelen behandelen van RESTful als architectuurstijl, zoals onafhankelijkheid tussen service consumers en providers in een applicatielandschap)"
			};

			goal31 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan een RESTful Web API (zelf ontworpen en van een bekende webapplicatie) classificeren volgens het Richardson maturity model."
			};

			goal32 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student ontwerpt en realiseert een (level 3) HATEOAS Web API volgens gangbare ontwerpregels en spreekt deze aan door een auto-genereerde GUI."
			};

			// Javascript-Typescript
			goal33 = new Goal
			{
				Bloom = "Apply",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend."
			};

			// No-SQL databases
			goal34 = new Goal
			{
				Bloom = "Apply",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend."
			};

			// Single Page Application web development individueel
			goal35 = new Goal
			{
				Bloom = "Apply",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend."
			};

			// Single page application webdevelopment project
			goal36 = new Goal
			{
				Bloom = "Apply",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend."
			};

			// Professionele Vaardigheden 3
			goal37 = new Goal
			{
				Bloom = "Apply",
				Description = @"TO DO : Inhoud en leerdoelen nog niet bekend."
			};

			// EIIN-BDRPR2: Bedrijfsprocessen 2
			goal38 = new Goal
			{
				Bloom = "Reproduce",
				Description = @"In eigen woorden een omschrijving geven van de begrippen: organisatie &  processen en besturing."
			};

			goal39 = new Goal
			{
				Bloom = "Reproduce",
				Description = @"Een overzicht gegeven van de verschillende deelgebieden binnen de bedrijfskunde."
			};

			goal40 = new Goal
			{
				Bloom = "Understand",
				Description = @"Zijn eigen activiteiten plaatsen binnen het geheel van der bedrijfsvoering van een organisatie en haar omgeving."
			};

			// EIIN-BIFRONT Business Intelligence Front-end
			goal41 = new Goal
			{
				Bloom = "Understand",
				Description = @"Understand Business Intelligence Information Needs."
			};

			goal42 = new Goal
			{
				Bloom = "Apply",
				Description = @"Define and Maintain the DW/BI Architecture."
			};

			goal43 = new Goal
			{
				Bloom = "Apply",
				Description = @"Implement Data Warehouses and Data Marts."
			};

			goal44 = new Goal
			{
				Bloom = "Apply",
				Description = @"Implement BI Tools and User Interfaces."
			};

			goal45 = new Goal
			{
				Bloom = "Apply",
				Description = @"Process data for Business Intelligence."
			};

			// EIIN-BIBACK Business Intelligence Back-end
			goal46 = new Goal
			{
				Bloom = "Understand",
				Description = @"In eigen woorden een omschrijving geven van het begrip ‘datawarehouse’."
			};

			goal47 = new Goal
			{
				Bloom = "Understand",
				Description = @"In eigen woorden de eigenschappen van (gegevens in) een datawarehouse beschrijven."
			};

			goal48 = new Goal
			{
				Bloom = "Understand",
				Description = @"In eigen woorden de begrippen multidimensionale database, feiten- en dimensietabel en ster- & snowflake-schema beschrijven."
			};

			goal49 = new Goal
			{
				Bloom = "Apply",
				Description = @"Uitgaande van een bestaande relationele database of een casusbeschrijving een ontwerpstructuur voor een datawarehouse maken."
			};

			goal50 = new Goal
			{
				Bloom = "Apply",
				Description = @"Een ontwerpstructuur voor een datawarehouse realiseren met behulp van SQL Server Data Tools."
			};

			goal51 = new Goal
			{
				Bloom = "Understand",
				Description = @"In eigen woorden het ETL-proces beschrijven."
			};

			goal52 = new Goal
			{
				Bloom = "Apply",
				Description = @"Uitgaande van bestaande gevarieerde bronnen een ETL proces uitvoeren met behulp van SQL Server Data Tools."
			};

			// EIIN-BIGDAT Big Data
			goal53 = new Goal
			{
				Bloom = "Understand",
				Description = @"In eigen woorden een omschrijving geven van het begrip ‘Big Data’."
			};

			goal54 = new Goal
			{
				Bloom = "Understand",
				Description = @"Een overzicht gegeven van de verschillende deelgebieden binnen Big Data."
			};

			goal55 = new Goal
			{
				Bloom = "Apply",
				Description = @"Een programma ontwikkelen waarmee sentiment-analyse, één van de deelgebieden binnen Big Data, uitgevoerd wordt."
			};

			goal56 = new Goal
			{
				Bloom = "Understand",
				Description = @"In eigen woorden een omschrijving geven van het begrip ‘Data Mining’."
			};

			goal57 = new Goal
			{
				Bloom = "Apply",
				Description = @"Met behulp van een tool Machine Learning, één van de deelgebieden binnen Data Mining, toepassen."
			};

			// EIIN-TECHENG, Technical English
			goal58 = new Goal
			{
				Bloom = "Apply",
				Description = @"The student can obtain information, ideas and opinions from highly specialised sources within the field of Information Technology in order to further their knowledge of important developments in the field."
			};

			goal59 = new Goal
			{
				Bloom = "Apply",
				Description = @"The student can participate in meetings in such a way that they can communicate on matters within the field of Information Technology animatedly, accurately and without impairment, exploiting appropriate language to do so.  "
			};

			goal60 = new Goal
			{
				Bloom = "Apply",
				Description = @"The student can write an executive summary in such a way that they develop an argument systematically with appropriate highlighting of significant points and relevant supporting detail, evaluating different ideas or solutions to a problem within the field of Information Technology. "
			};

			goal61 = new Goal
			{
				Bloom = "Apply",
				Description = @"The student can check the meaning of less common professional vocabulary and expressions using websites, forums and single language dictionaries in order to broaden their vocabulary in the field of Information Technology.   "
			};

			goal62 = new Goal
			{
				Bloom = "Apply",
				Description = @"The student is able to use professional vocabulary related to the field of Information Technology in such a way that communication with clients and other professionals in the field is accurate and unimpaired."
			};

			// EIIN-SECU1 Security 1
			goal63 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt de begrippen asset, vulnerability, threat, control, attack, zodanig dat je ze in eigen woorden kunt uitleggen wat de betekenis en samenhang zijn in de context van software security."
			};

			goal64 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt de 4 basis-threats (i.e. interruption, interception, modification, fabrication), zodanig dat je ze in eigen woorden kunt uitleggen wat de betekenis en samenhang zijn in de context van software security."
			};

			goal65 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je herkent de begrippen security goals/requirements, zodanig dat je ze in eigen woorden kunt uitleggen wat de betekenis en samenhang zijn in de context van software security."
			};

			goal66 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt in grote lijnen hoe een cryptografisch systeem werkt in termen van symmetrische/assymetrische encryptie, hashing, salting, mac, nonce en  symmetrische/assymetrische digitale handtekening, zodanig dat je in eigen woorden kunt uitleggen hoe versleutelde informatieoverdracht werkt."
			};

			goal67 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			goal68 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt wat personalisation is, zodanig dat je ze in eigen woorden kunt uitleggen wat de betekenis is in de context van software security."
			};

			goal69 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt in grote lijnen hoe de security-protocollen http basic authentication, block chain, ssl/tls en vpn werken, zodanig dat je in eigen woorden kunt uitleggen hoe deze bijdragen aan de beveiliging van softwareapplicaties op netwerkniveau (transport level). "
			};

			goal70 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je begrijpt in grote lijnen hoe de security-infrastructuren pki, kerberos, oauth en openid werken, zodanig dat je in eigen woorden kunt uitleggen hoe deze bijdragen aan de beveiliging van softwareapplicaties."
			};

			goal71 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je kunt in eigen woorden uitleggen hoe kwetsbaarheden (vulnerabilities) in software ontstaan, zodanig dat je in eigen woorden kunt uitleggen dat software niet vanzelf secure is."
			};

			goal72 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je herkent de vulnerabilities MiM, session hijacking, spoofing, parameter modification, TOCTOU, cookie, eavesdropping, exposure within network, zodanig dat je in eigen woorden uit kunt leggen waarom hiervoor security maatregelen getroffen moeten worden in een softwareapplicatie."
			};

			goal73 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je herkent de attacks SQL injection, command injection, cross-site scripting (XSS), cookie poisoning en session hijacking en een aantal soorten malware zodanig dat je in eigen woorden kunt uitleggen hoe ze werken en welke bedreiging ze vormen voor softwareapplicaties."
			};

			goal74 = new Goal
			{
				Bloom = "Understand",
				Description = @"Je herkent de controls xyz, zodanig dat je in eigen woorden uit kunt leggen waarom deze een oplossing zijn voor vulnerabilities van en attacks op een softwareapplicatie."
			};

			goal75 = new Goal
			{
				Bloom = "Apply",
				Description = @"Je kunt de informatie van de organisatie OWASP raadplegen, zodanig dat je controls tegen vulnerabilities kunt implementeren."
			};

			goal76 = new Goal
			{
				Bloom = "Apply",
				Description = @"Je kunt controls toepassen, zodanig dat je een streaming applicatie kunt beveiligen tegen minimaal één voorkomen van elke threat (interruption, interception, modification, fabrication)."
			};

			// EIIN - CONETW2 Computernetwerken 2
			goal77 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student gebruikt netwerktools, zodanig dat hij netwerkverkeer analyseert."
			};

			goal78 = new Goal
			{
				Bloom = "Evaluate",
				Description = @"De student maakt een onderbouwde keuze voor TCP of UDP, zodanig dat hij het meest geschikte protocol voor een situatie kiest."
			};

			goal79 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student implementeert HTTP zonder library, zodanig dat hij een simpele HTTP server maakt."
			};

			goal80 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student implementeert IMAP en SMTP, zodanig dat hij een e-mailapplicatie maakt."
			};

			goal81 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student implementeert LDAP, zodanig dat hij een directoryservice integreert."
			};

			goal82 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student implementeert RTP, zodanig dat hij live videobeelden streamt."
			};

			goal83 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student implementeert FTP, zodanig dat hij bestanden uitwisselt tussen twee locaties."
			};

			goal84 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student begrijpt het doel van een CDN, zodanig dat hij uitlegt wat de toegevoegde waarde voor een streamingdienst is."
			};

			// EIIN-VERDICT Verdieping ICT
			goal85 = new Goal
			{
				Bloom = "Evaluate",
				Description = @"Een keuze bepalen voor een voor de ICT-sector relevant onderwerp."
			};

			goal86 = new Goal
			{
				Bloom = "Apply",
				Description = @"Zelfstandig een planning maken ter bestudering van het gekozen onderwerp."
			};

			goal87 = new Goal
			{
				Bloom = "Apply",
				Description = @"Activiteiten uit die planning zelfstandig uitvoeren."
			};

			goal88 = new Goal
			{
				Bloom = "Apply",
				Description = @"Rapporteren over de uitgevoerde werkzaamheden."
			};

			// EIIN-DZONT2 Duurzame Ontwikkeling 2
			goal89 = new Goal
			{
				Bloom = "Understand",
				Description = @"De student kent de rol van lean ICT-ontwikkeling, zodanig dat hij dit kan relateren aan greening of ICT"
			};

			goal90 = new Goal
			{
				Bloom = "Understand",
				Description = @"De student begrijpt lean ICT, zodanig dat hij de zeven principes ervan kan benoemen"
			};

			goal91 = new Goal
			{
				Bloom = "Understand",
				Description = @"De student begrijpt lean ICT, zodanig dat hij de zeven principes ervan kan uitleggen"
			};

			goal92 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student begrijpt de zeven principes van lean ICT, zodanig dat hij ze kan relateren aan zde voorafgaande studieperiodes"
			};

			// EIIN-ORVA2, Onderzoeksvaardigheden 2
			goal93 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student brengt uiteenlopende items onder in een coherente indeling, zodanig dat hierbij een redeneerschema kan worden opgesteld."
			};

			goal94 = new Goal
			{
				Bloom = "Understand",
				Description = @"De student kan standpunten en redenen identificeren, zodanig dat hij een redenatieschema kan opstellen en beoordelen."
			};

			goal95 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan een hiërarchie aanbrengen in redenen, zodanig dat hij een redenatieschema kan opstellen en beoordelen."
			};

			goal96 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student co-premissen formuleren bij redeneringen, zodanig dat hij een redenatieschema kan opstellen en beoordelen."
			};

			goal97 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan beweringen in teksten zó herformuleren dat zij in een schematische analyse kunnen worden geplaatst;"
			};

			goal98 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan een betoog analyseren en hierbij een redenatieschema opstellen, zodanig dat alle elementen uit het betoog terugkomen in het redenatieschema;"
			};

			goal99 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan een betoog schrijven, onderbouwd met argumenten uit een redenatieschema, zodanig dat alle elementen uit het redenatieschema terugkomen in het betoog;"
			};

			goal100 = new Goal
			{
				Bloom = "Apply",
				Description = @"De student kan een overtuigende tekst schrijven volgens richtlijnen beschreven in Elling et al (2015)."
			};

			return new List<Goal>
			{
				goal1,
				goal2,
				goal3,
				goal4,
				goal5,
				goal6,
				goal7,
				goal8,
				goal9,
				goal10,
				goal11,
				goal12,
				goal13,
				goal14,
				goal15,
				goal16,
				goal17,
				goal18,
				goal19,
				goal20,
				goal21,
				goal22,
				goal23,
				goal24,
				goal25,
				goal26,
				goal27,
				goal28,
				goal29,
				goal30,
				goal31,
				goal32,
				goal33,
				goal34,
				goal35,
				goal36,
				goal37,
				goal38,
				goal39,
				goal40,
				goal41,
				goal42,
				goal43,
				goal44,
				goal45,
				goal46,
				goal47,
				goal48,
				goal49,
				goal50,
				goal51,
				goal52,
				goal53,
				goal54,
				goal55,
				goal56,
				goal57,
				goal58,
				goal59,
				goal60,
				goal61,
				goal62,
				goal63,
				goal64,
				goal65,
				goal66,
				goal67,
				goal68,
				goal69,
				goal70,
				goal71,
				goal72,
				goal73,
				goal74,
				goal75,
				goal76,
				goal77,
				goal78,
				goal79,
				goal80,
				goal81,
				goal82,
				goal83,
				goal84,
				goal85,
				goal86,
				goal87,
				goal88,
				goal89,
				goal90,
				goal91,
				goal92,
				goal93,
				goal94,
				goal95,
				goal96,
				goal97,
				goal98,
				goal99,
				goal100,
			};
		}

		/// <summary>
		/// Seed exams.
		/// </summary>
		/// <returns>An array of exams.</returns>
		public static List<Exam> GetExams()
		{
			exam1 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(100),
				EC = 3,
				ExamType = "K:open-vragen(R) + Vh:projectopdracht",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher1,
				Weight = 1
			};

			exam2 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 5,
				ExamType = "Vh:projectopdracht + Vh:criteriumgericht-interview",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher1,
				Weight = 1
			};

			exam3 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 5,
				ExamType = "Vh:projectopdracht",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher1,
				Weight = 1
			};

			exam4 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(200),
				EC = 3,
				ExamType = "Vh:vaardigheidstoets(R)",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher1,
				Weight = 1
			};

			exam5 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(150),
				EC = 2,
				ExamType = "K:open-vragen(R) + vh:presentatie",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher1,
				Weight = 1
			};

			exam6 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(150),
				EC = 4,
				ExamType = "vh:vaardigheidstoets(R) + voortgangstoets",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher2,
				Weight = 1
			};

			exam7 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(150),
				EC = 4,
				ExamType = "vh:vaardigheidstoets(R) + voortgangstoets",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher2,
				Weight = 1
			};

			exam8 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 3,
				ExamType = "Vh:criteriumgericht-interview",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher2,
				Weight = 1
			};

			exam9 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 3,
				ExamType = "Vh:criteriumgericht-interview",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher2,
				Weight = 1
			};

			exam10 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 1,
				ExamType = "Vh:verslag",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher2,
				Weight = 1
			};

			exam11 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(100),
				EC = 4,
				ExamType = "K:MC-toets(R)",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher3,
				Weight = 1
			};

			exam12 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(100),
				EC = 1,
				ExamType = "K:MC-toets(R)",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher3,
				Weight = 1
			};

			exam13 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 2,
				ExamType = "VH:Portfolio-assessment",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher3,
				Weight = 1
			};

			exam14 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 3,
				ExamType = "VH:Portfolio-assessment",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher3,
				Weight = 1
			};

			exam15 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 3,
				ExamType = "Vh:projectopdracht",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher3,
				Weight = 1
			};

			exam16 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(100),
				EC = 2,
				ExamType = "Vh:essaytoets + vh+att:gedragsassessment + vh:portfolio-assessment + vh:vaardigheidstoets(R)",
				GradeType = "Grade",
				Language = "EN",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher3,
				Weight = 1
			};

			exam17 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(150),
				EC = 4,
				ExamType = "K:open-vragen(R) + vh:projectopdracht+criteriumgericht-interview",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher4,
				Weight = 1
			};

			exam18 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(150),
				EC = 4,
				ExamType = "K:open-vragen(R) + vh:projectopdracht+criteriumgericht-interview",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher4,
				Weight = 1
			};

			exam19 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(0),
				EC = 2,
				ExamType = "K+vh:portfolio-assessment",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher4,
				Weight = 1
			};

			exam20 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(100),
				EC = 2,
				ExamType = "K:MC-toets(R) + voortgangstoets",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher4,
				Weight = 1
			};

			exam21 = new Exam()
			{
				AttemptOne = new DateTime(2018, 10, 20),
				AttemptTwo = new DateTime(2018, 10, 22),
				Compensatable = false,
				Duration = new TimeSpan(100),
				EC = 3,
				ExamType = "Vh:verslag",
				GradeType = "Grade",
				Language = "NL",
				PassingGrade = 5.5,
				ResponsibleTeacher = teacher4,
				Weight = 1
			};

			return new List<Exam>
			{
				exam1,
				exam2,
				exam3,
				exam4,
				exam5,
				exam6,
				exam7,
				exam8,
				exam9,
				exam10,
				exam11,
				exam12,
				exam13,
				exam14,
				exam15,
				exam16,
				exam17,
				exam18,
				exam19,
				exam20,
				exam21
			};
		}

		/// <summary>
		/// Seed teacher modules.
		/// </summary>
		/// <returns>An array of teacher modules</returns>
		public static List<TeacherModule> GetTeacherModules()
		{
			teacherModule1 = new TeacherModule()
			{
				ModuleId = module1.Id,
				TeacherId = teacher1.Id
			};

			teacherModule2 = new TeacherModule()
			{
				ModuleId = module2.Id,
				TeacherId = teacher1.Id
			};

			teacherModule3 = new TeacherModule()
			{
				ModuleId = module3.Id,
				TeacherId = teacher1.Id
			};

			teacherModule4 = new TeacherModule()
			{
				ModuleId = module4.Id,
				TeacherId = teacher1.Id
			};

			teacherModule5 = new TeacherModule()
			{
				ModuleId = module5.Id,
				TeacherId = teacher1.Id
			};

			teacherModule6 = new TeacherModule()
			{
				ModuleId = module6.Id,
				TeacherId = teacher2.Id
			};

			teacherModule7 = new TeacherModule()
			{
				ModuleId = module7.Id,
				TeacherId = teacher2.Id
			};

			teacherModule8 = new TeacherModule()
			{
				ModuleId = module8.Id,
				TeacherId = teacher2.Id
			};

			teacherModule9 = new TeacherModule()
			{
				ModuleId = module9.Id,
				TeacherId = teacher2.Id
			};

			teacherModule10 = new TeacherModule()
			{
				ModuleId = module10.Id,
				TeacherId = teacher2.Id
			};

			teacherModule11 = new TeacherModule()
			{
				ModuleId = module11.Id,
				TeacherId = teacher3.Id
			};

			teacherModule12 = new TeacherModule()
			{
				ModuleId = module12.Id,
				TeacherId = teacher3.Id
			};

			teacherModule13 = new TeacherModule()
			{
				ModuleId = module13.Id,
				TeacherId = teacher3.Id
			};

			teacherModule14 = new TeacherModule()
			{
				ModuleId = module14.Id,
				TeacherId = teacher3.Id
			};

			teacherModule15 = new TeacherModule()
			{
				ModuleId = module15.Id,
				TeacherId = teacher3.Id
			};

			teacherModule16 = new TeacherModule()
			{
				ModuleId = module16.Id,
				TeacherId = teacher3.Id
			};

			teacherModule17 = new TeacherModule()
			{
				ModuleId = module17.Id,
				TeacherId = teacher4.Id
			};

			teacherModule18 = new TeacherModule()
			{
				ModuleId = module18.Id,
				TeacherId = teacher4.Id
			};

			teacherModule19 = new TeacherModule()
			{
				ModuleId = module19.Id,
				TeacherId = teacher4.Id
			};

			teacherModule20 = new TeacherModule()
			{
				ModuleId = module20.Id,
				TeacherId = teacher4.Id
			};

			teacherModule21 = new TeacherModule()
			{
				ModuleId = module21.Id,
				TeacherId = teacher4.Id
			};

			return new List<TeacherModule>
			{
				teacherModule1,
				teacherModule2,
				teacherModule3,
				teacherModule4,
				teacherModule5,
				teacherModule6,
				teacherModule7,
				teacherModule8,
				teacherModule9,
				teacherModule10,
				teacherModule12,
				teacherModule13,
				teacherModule14,
				teacherModule15,
				teacherModule16,
				teacherModule17,
				teacherModule18,
				teacherModule19,
				teacherModule20,
				teacherModule21
			};
		}

		/// <summary>
		/// Seed teachers.
		/// </summary>
		/// <returns>An array of teachers.</returns>
		public static List<Teacher> GetTeachers()
		{
			teacher1 = new Teacher()
			{
				FirstName = "Qurratulain",
				LastName = "Mubarak"
			};

			teacher2 = new Teacher()
			{
				FirstName = "Robin",
				LastName = "Schellius"
			};

			teacher3 = new Teacher()
			{
				FirstName = "Gerard",
				LastName = "Wagenaar"
			};

			teacher4 = new Teacher()
			{
				FirstName = "Arno",
				LastName = "Broeders"
			};

			return new List<Teacher>
			{
				teacher1,
				teacher2,
				teacher3,
				teacher4
			};
		}

		/// <summary>
		/// Seed logitems.
		/// </summary>
		/// <returns>An array of teachers.</returns>
		public static List<LogItem> GetLogitems()
		{
			return new List<LogItem>()
			{
				new LogItem()
				{
					Message = "Robin Schellius heeft een course met de naam 'Typescript/Javascript' verwijderd",
					LogType = LogType.Delete,
					CreatedAt = DateTime.Now

				},
				new LogItem()
				{
					Message = "Robin Schellius heeft een course met de naam 'Bussiness Intelligence Front-end' verwijderd",
					LogType = LogType.Delete,
					CreatedAt = DateTime.Now
				}
			};
		}

		public static List<LearningLine> GetLearningLines()
		{
			learningLine1 = new LearningLine()
			{
				Name = "Bedrijfskunde"
			};

			learningLine2 = new LearningLine()
			{
				Name = "HCI"
			};

			learningLine3 = new LearningLine()
			{
				Name = "Beheer"
			};

			learningLine4 = new LearningLine()
			{
				Name = "Requirements Engineering"
			};

			learningLine5 = new LearningLine()
			{
				Name = "Software design and Architecture"
			};
			learningLine6 = new LearningLine()
			{
				Name = "Programmeren"
			};

			learningLine7 = new LearningLine()
			{
				Name = "Databases"
			};

			learningLine8 = new LearningLine()
			{
				Name = "Testen"
			};

			learningLine9 = new LearningLine()
			{
				Name = "Solution Architecture"
			};

			learningLine10 = new LearningLine()
			{
				Name = "Computernetwerken"
			};

			learningLine11 = new LearningLine()
			{
				Name = "Security"
			};

			learningLine12 = new LearningLine()
			{
				Name = "Duurzame ontwikkeling"
			};

			learningLine13 = new LearningLine()
			{
				Name = "Onderzoeksvaardigheden"
			};

			learningLine14 = new LearningLine()
			{
				Name = "Professionele vaardigheden"
			};

			learningLine15 = new LearningLine()
			{
				Name = "Engels"
			};

			return new List<LearningLine>()
			{
				learningLine1,
				learningLine2,
				learningLine3,
				learningLine4,
				learningLine5,
				learningLine6,
				learningLine7,
				learningLine8,
				learningLine9,
				learningLine10,
				learningLine11,
				learningLine12,
				learningLine13,
				learningLine14,
				learningLine15
			};
		}

		public static ICollection<LearningLineGoal> GetLearningLinesGoals()
		{
			return new List<LearningLineGoal>()
			{
				   new LearningLineGoal()
				   {
					   LearningLineId = learningLine1.Id,
					   GoalId = goal1.Id
				   },
				   new LearningLineGoal()
				   {
					   LearningLineId = learningLine2.Id,
					   GoalId = goal2.Id
				   },
				   new LearningLineGoal()
				   {
					   LearningLineId = learningLine3.Id,
					   GoalId = goal3.Id
				   },
				   new LearningLineGoal()
				   {
					   LearningLineId = learningLine3.Id,
					   GoalId = goal4.Id
				   }
			};
		}
	}
}
