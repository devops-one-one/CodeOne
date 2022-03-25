FROM node:16-alpine as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/gym-one-fr /usr/share/nginx/html
