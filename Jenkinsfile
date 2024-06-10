pipeline {
    agent any
    tools{
        jdk  'jdk17'
        maven  'maven3'
    }    
    environment
    {
        SCANNER_HOME= tool 'sonar-scanner'
        SONARQUBE_IMAGE_NAME = 'sonarqube:latest'
        JENKINS_IMAGE_NAME = 'jenkins/jenkins'
    }
    stages {
        stage('Git Checkout') {
            steps {
                git branch: 'Dev', credentialsId: 'RelationalDatabases', url: 'https://github.com/tselloss/ActyIn'
            }
        }
        
        stage('OWASP Dependency Check') {
            steps {
                dependencyCheck additionalArguments: ' --scan ./ ', odcInstallation: 'DC'
                    dependencyCheckPublisher pattern: '**/dependency-check-report.xml'
            }
        }

        stage('File System Scan') {
            steps {
                sh "/var/jenkins_home/workspace/trivy fs ."
            }
        }

        stage('Sonarqube Image Scan') {
            steps {
                 sh "/var/jenkins_home/workspace/trivy repo https://github.com/SonarSource/docker-sonarqube.git"
            }
        }

        stage('Jenkins Image Scan') {
            steps {               
                sh "/var/jenkins_home/workspace/trivy image ${JENKINS_IMAGE_NAME}"
            }
        }
        
       stage('Sonarqube Analysis') {
            steps {
                withSonarQubeEnv('sonar'){
                sh '''mvn clean verify sonar-scanner:sonar-scanner -X \
                -Dsonar.projectName=httpClientApp \
                -Dsonar.java.binaries=. \
                -Dsonar.projectKey=httpClientApp'''
            }
        }
       }
   }
}
