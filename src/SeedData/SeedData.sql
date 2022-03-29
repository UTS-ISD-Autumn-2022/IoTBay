INSERT INTO [Categories]
VALUES (
        'Development Boards, Evaluation Tools',
        'Here at IoTBay we have a huge stock of Development Boards & Evaluation Kits, from industry-leading manufacturers in stock that can be delivered free next day.',
        'https://au.element14.com/wcsstore/ExtendedSitesCatalogAssetStore/cms/asset/images/apac/common/homepage_new/dev-kits.jpg'
);
INSERT INTO [Categories]
VALUES (
        'Embedded Computers, Education & Maker Boards',
        'Low cost, rapid prototyping and development with the latest range of embedded computers. Choose from a range of ready-made boards, many with wifi connectivity that act as a gateway device for IoT, reducing both the cost and complexity of designing your own solution from scratch. Whatever your use type or application, choose from a complete ecosystem of Single Board Computers, expansion boards and peripherals that encourage and enable your creative ideas to become a reality.',
        'https://au.element14.com/wcsstore/ExtendedSitesCatalogAssetStore/cms/asset/images/apac/common/homepage_new/dev-kits.jpg'
);
INSERT INTO [Categories]
VALUES (
        'Engineering Software',
        'Optimise and protect your computer systems with our extensive selection of software and debugger tools, including CAD and simulation tools, debuggers, emulators and JTAG tools, compilers/IDE, embedded operating systems, programmers, erasers, accessories and more.',
        'https://au.element14.com/wcsstore/ExtendedSitesCatalogAssetStore/cms/asset/images/apac/common/homepage_new/dev-kits.jpg'
);
INSERT INTO [Categories]
VALUES (
        'Connectors',
        'IoTBay offers a comprehensive range of connector products including PCB connectors, D-sub connectors, I/O connectors, industrial connectors, RF/Coaxial connectors, audio & video connectors and many more from leading manufacturers, catering to a wide spectrum of applications.',
        'https://au.element14.com/wcsstore/ExtendedSitesCatalogAssetStore/cms/asset/images/apac/common/homepage_new/interconnect.jpg?v=2'
);
INSERT INTO [Categories]
VALUES (
        'Cable, Wire & Cable Assemblies',
        'Element 14 Cable & Wire Solutions for Every Environment. Hook-up, Multicore, Coax, Ribbon… you name it, we’ve got it! With top-quality products available from all the leading brands, Farnell can solve all your Cable needs. Cable types include Tri-Rated Wire, Control Panel Wire, Switchgear Cable, BS6231 Wire and H05V2-K Wire and many more.',
        'https://au.element14.com/wcsstore/ExtendedSitesCatalogAssetStore/cms/asset/images/apac/common/homepage_new/interconnect.jpg?v=2'
);
INSERT INTO [Categories]
VALUES (
        'Optoelectronics',
        'element14 has a comprehensive range of Optoelectronics & Displays from the world''s leading manufacturers.',
        'https://au.element14.com/wcsstore/ExtendedSitesCatalogAssetStore/cms/asset/images/apac/common/homepage_new/optoelectronics.jpg'
);
GO;

INSERT INTO [Products] ([Name], [Description], [ImgUrl], [CategoryId], [StockLevel], [OnOrder], [Price])
VALUES (
        'Starter Kit, Arduino UNO, Projects Book, Breadboard, Components Kit (English)',
        'The K000007 is an Arduino starter kit. This kit walks us through the basics in a hands on way, with creative projects we build by learning, thanks to a selection of the most common and useful electronic components with a selection of 15 projects that start from a low complexity, in order to learn the basic of electronic, to a major one, using components that let to control the physical world throw different kind of sensor. Once we have mastered this knowledges, we will have a palette of software and circuits that we can use to create something beautiful and make someone smile with what we invent, that is the reason why we will find more components than the required from the projects of the book. Then build it, hack it and share it.',
        'https://au.element14.com/arduino/k000007/starter-kit-arduino-with-uno-board/dp/2250862',
        2,
        35,
        10,
        175.50
);
INSERT INTO [Products] ([Name], [Description], [ImgUrl], [CategoryId], [StockLevel], [OnOrder], [Price])
VALUES (
        'Development Board, Arduino Uno SMD, Revision 3, ATmega328 MCU, 14 Digital I/O, 6 Analogue I/P, 5V',
        'The A000073 is a Arduino Uno SMD R3 development board based on the ATmega328 microcontroller. The ATmega328 is a low power CMOS 8bit microcontroller based on the AVR enhanced RISC architecture. By executing powerful instructions in a single clock cycle, the ATmega328 achieves throughputs approaching 1MIPS per MHz allowing the system designer to optimize power consumption versus processing speed. The Arduino Uno SMD R3 evaluation board has 14 digital input/output pins (of which 6 can be used as PWM outputs), 6 analog inputs, a 16MHz crystal oscillator, a USB connection, a power jack, an ICSP header and a reset button. It contains everything needed to support the microcontroller, simply connect it to a computer with a USB cable or power it with a AC to DC adapter or battery to get started. The Uno differs from all preceding boards in that it does not use the FTDI USB to serial driver chip.',
        'https://au.element14.com/productimages/standard/en_GB/2285200-40.jpg',
        2,
        25,
        13,
        42.50
);
