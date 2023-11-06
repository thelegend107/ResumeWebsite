<script setup>
import WelcomeItem from './WelcomeItem.vue'
import DocumentationIcon from './icons/IconDocumentation.vue'
import ToolingIcon from './icons/IconTooling.vue'
import EcosystemIcon from './icons/IconEcosystem.vue'
import CommunityIcon from './icons/IconCommunity.vue'
import SupportIcon from './icons/IconSupport.vue'
</script>

<template>
  <WelcomeItem>
    <template #icon>
      <DocumentationIcon />
    </template>
    <template #heading>Education</template>
      South Dakota State University
    <br>
      August 2015 – May 2020
    <br>
      Bachelor's Degree in Electrical Engineering and a minor in Mathematics
    <br>
      GPA 3.2
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <ToolingIcon />
    </template>
    <template #heading>Work Experience</template>
    
    <b class="electricPurple">Raven Indusrties Inc. - IT Software Developer</b>
    <br>
    <b class="electricPurple">October 2020 – September 2023</b>
    <ul>
      <li>Product owner and main contributor to our E-Commerce web site for the Agricultural Division. Utilizes Azure Web App, Service Bus Message Queues, Web Job, SQL database, and Visual Studios</li>
      <li>Integrated our E-Commerce web site to Raven's new ERP system. Utilizing C#, Azure Web App, Message Service Bus Queues, Web Job, MSSQL, and Oracle SQL</li>
      <li>Integrated our 3rd party CRM (Salesforce) system with Raven’s current ERP system. Utilizes C#, Boomi, and Oracle. Then re-did the integration by building a .NET library (SOAP) for Salesforce and creating .NET console apps to sync data between Raven’s current ERP and Salesforce</li>
      <li>Integrated our IT ticketing system (Ivanti) with Azure DevOps by building a .NET 6 console app</li>
      <li>Developed Salesforce LWC, Aura, and APEX classes to enhance Raven’s business processes</li>
    </ul>
    
    <br>
    <b class="electricPurple">Flexon Technologies - Business Analyst</b>
    <br>
    <b class="electricPurple">October 2020 – September 2023</b>
    <br>
    <ul>
      <li>In-depth knowledge of Software Development Life Cycle</li>
      <li>Extensive experience with SCRUM to accommodate requirement changes and promote flexibility</li>
      <li>Ability to elicit, analyze, gather, document, and prioritize requirements and specifications for complex and simple projects</li>
      <li>Extensive experience in querying SQL databases for data analysis purposes</li>
    </ul>
    
    <br>
    <b class="electricPurple">Daktronics - Senior Design Project</b>
    <br>
    <b class="electricPurple">August 2019 – May 2020</b>
    <br>
    <ul>
      <li>Designed a device that can gain physical access to the network settings of Daktronics’s display controllers (host device) and to reconfigure those network settings as needed</li>
      <li>Responsible for programming the microprocessor and the C# application that allows the microprocessor to communicate with the host device</li>
      <li>Created a setup file for the C# application for easy installation of the C# application</li>
      <li>Designed and built the PCB for the device</li>
    </ul>

    <br>
    <b class="electricPurple">Sencore Inc. - Application Engineer Intern</b>
    <br>
    <b class="electricPurple">May 2018 – August 2019</b>
    <br>
    <ul>
      <li>Led the software and hardware testing for Sencore and WELLAV products to ensure products met or exceeded specifications</li>
      <li>Responsible for determining the root cause of customer reported issues and reporting the results to the Application Engineering team for resolution</li>
      <li>Collaborated with the Engineering department to enhance the stability and performance of development products</li>
    </ul>

    <br>
    <b class="electricPurple">SDSU Performing Arts Center - Technician</b>
    <br>
    <b class="electricPurple">September 2017 – May 2018</b>
    <br>
    <ul>
      <li>Responsible for running wires to the stage speakers and setting up the lighting system</li>
      <li>Troubleshooting defective equipment during live performances</li>
    </ul>
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <EcosystemIcon />
    </template>
    <template #heading>Skills</template>
    Azure ⦁ C# ⦁ C ⦁ C++ ⦁ MATLAB ⦁ Python ⦁ Verilog ⦁ TensorFlow ⦁ MPLAB ⦁ Batch scripts ⦁ Arduino ⦁ .NET ⦁ MSSQL ⦁ Oracle SQL ⦁ Azure DevOps ⦁ Git ⦁ Windows Server ⦁ Linux (RedHat, Ubuntu) ⦁ JavaScript ⦁ HTML ⦁ CSS ⦁ MS Visio
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <CommunityIcon />
    </template>
    <template #heading>Certifications</template>
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <SupportIcon />
    </template>
    <template #heading>Support Vue</template>
  </WelcomeItem>
</template>

<style scoped>
ul {
  padding-left: 5%;
}
</style>