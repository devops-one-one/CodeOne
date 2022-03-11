pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  environment {
    COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")
  }
  stages{
    stage("Startup"){
      steps{
        buildDescription env.COMMITMSG
        dir("TestProject1"){
          sh "rm -rf TestResults"
        }
      }
    }
    stage("Build API"){
      steps{
        sh "dotnet build GymOneBackend/GymOneBackend.sln"
      }
    }
    stage("Build Frontend"){
          steps{
            dir('gym-one-fr') {
              sh "ng build --prod"
              }
      }
      }
      stage("Test"){
        steps{
          dir("TestProject"){
            sh "dotnet add package coverlet.collector"
            sh "dotnet test --collect:'Xplat Code Coverage'"
          }
        }
        post{
          success{
            archiveArtifacts "TestProject1/TestReults/*/coverage.cobertura.xml"
          }
        }
      }
  }
}