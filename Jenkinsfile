pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  stages{
    stage("Build Backend"){
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
  }
}
