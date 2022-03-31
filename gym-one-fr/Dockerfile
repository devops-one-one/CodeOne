FROM node:16-alpine as node
WORKDIR /app
COPY . .

FROM nginx:alpine
COPY --from=node /app/dist/gym-one-fr /usr/share/nginx/html
